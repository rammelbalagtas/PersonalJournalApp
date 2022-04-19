
// Test browser support
window.SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition || null;

if (window.SpeechRecognition === null) {

}

else {

    var descriptionText = document.getElementById('Description');
    var descriptionBtn = document.getElementById('description-text-btn');
    var micDescription = document.getElementById('mic-desc');

    var subsectionText1 = document.getElementById('SubsectionText1');
    var subsection1Btn = document.getElementById('subsection1-text-btn');
    var micSub1 = document.getElementById('mic-sub1');

    var subsectionText2 = document.getElementById('SubsectionText2');
    var subsection2Btn = document.getElementById('subsection2-text-btn');
    var micSub2 = document.getElementById('mic-sub2');

    var subsectionText3 = document.getElementById('SubsectionText3');
    var subsection3Btn = document.getElementById('subsection3-text-btn');
    var micSub3 = document.getElementById('mic-sub3');

    var subsectionText4 = document.getElementById('SubsectionText4');
    var subsection4Btn = document.getElementById('subsection4-text-btn');
    var micSub4 = document.getElementById('mic-sub4');

    var subsectionText5 = document.getElementById('SubsectionText5');
    var subsection5Btn = document.getElementById('subsection5-text-btn');
    var micSub5 = document.getElementById('mic-sub5');

    var recognizing;
    var isInterim;
    var textHolder;
    var elementId;

    var recognizer = new window.SpeechRecognition();
    recognizer.continuous = true;
    recognizer.interimResults = true;
    recognizing = false;

    recognizer.onresult = function (event) {

        switch (elementId) {
            case "description-text-btn":
                handleOnResultSpeech(descriptionText);
                break;
            case "subsection1-text-btn":
                handleOnResultSpeech(subsectionText1);
                break;
            case "subsection2-text-btn":
                handleOnResultSpeech(subsectionText2);
                break;
            case "subsection3-text-btn":
                handleOnResultSpeech(subsectionText3);
                break;
            case "subsection4-text-btn":
                handleOnResultSpeech(subsectionText4);
                break;
            case "subsection5-text-btn":
                handleOnResultSpeech(subsectionText5);
                break;
        }

    }

    //attach event listeners
    descriptionBtn.addEventListener('click', onMicButtonClick);
    subsection1Btn.addEventListener('click', onMicButtonClick);
    subsection2Btn.addEventListener('click', onMicButtonClick);
    subsection3Btn.addEventListener('click', onMicButtonClick);
    subsection4Btn.addEventListener('click', onMicButtonClick);
    subsection5Btn.addEventListener('click', onMicButtonClick);

    function handleOnResultSpeech(subsectionText) {

        var interim_transcript = "";

        if (!isInterim) {
            textHolder = subsectionText.value + " "; //transfer current value to a temp variable
            isInterim = true //start interim recognition
        }

        //once recognition is final, move back the previous value and append the final transcript
        if (event.results[event.resultIndex].isFinal) {
            isInterim = false;
            subsectionText.value = textHolder;
        }

        for (var i = event.resultIndex; i < event.results.length; ++i) {
            if (event.results[i].isFinal) {
                subsectionText.value += event.results[i][0].transcript;
            } else {
                interim_transcript += event.results[i][0].transcript;
            }
        }

        //while interim recognition is running, keep replacing the subtext value with 
        //interim transcript
        if (isInterim) {
            subsectionText.value = textHolder + interim_transcript;
        }
    }

    //event handler method for onclick of mic buttons
    function onMicButtonClick() {
        elementId = document.activeElement.id;
        if (recognizing) {
            recognizer.stop();
            recognizing = false;
            switch(elementId) {
                case "description-text-btn":
                    micDescription.src = "../mic.gif";
                    micSub1.hidden = false;
                    micSub2.hidden = false;
                    micSub3.hidden = false;
                    micSub4.hidden = false;
                    micSub5.hidden = false;
                    break;
                case "subsection1-text-btn":
                    micSub1.src = "../mic.gif";
                    micDescription.hidden = false;
                    micSub2.hidden = false;
                    micSub3.hidden = false;
                    micSub4.hidden = false;
                    micSub5.hidden = false;
                    break;
                case "subsection2-text-btn":
                    micSub2.src = "../mic.gif";
                    micDescription.hidden = false;
                    micSub1.hidden = false;
                    micSub3.hidden = false;
                    micSub4.hidden = false;
                    micSub5.hidden = false;
                    break;
                case "subsection3-text-btn":
                    micSub3.src = "../mic.gif";
                    micDescription.hidden = false;
                    micSub1.hidden = false;
                    micSub2.hidden = false;
                    micSub4.hidden = false;
                    micSub5.hidden = false;
                    break;
                case "subsection4-text-btn":
                    micSub4.src = "../mic.gif";
                    micDescription.hidden = false;
                    micSub1.hidden = false;
                    micSub2.hidden = false;
                    micSub3.hidden = false;
                    micSub5.hidden = false;
                    break;
                case "subsection5-text-btn":
                    micSub5.src = "../mic.gif";
                    micDescription.hidden = false;
                    micSub1.hidden = false;
                    micSub2.hidden = false;
                    micSub3.hidden = false;
                    micSub4.hidden = false;
                    break;
            }
        } else {
            recognizer.start();
            recognizing = true;
            switch(elementId) {
                case "description-text-btn":
                    micDescription.src = "../mic-animate.gif";
                    micSub1.hidden = true;
                    micSub2.hidden = true;
                    micSub3.hidden = true;
                    micSub4.hidden = true;
                    micSub5.hidden = true;
                    break;
                case "subsection1-text-btn":
                    micSub1.src = "../mic-animate.gif";
                    micDescription.hidden = true;
                    micSub2.hidden = true;
                    micSub3.hidden = true;
                    micSub4.hidden = true;
                    micSub5.hidden = true;
                    break;
                case "subsection2-text-btn":
                    micSub2.src = "../mic-animate.gif";
                    micDescription.hidden = true;
                    micSub1.hidden = true;
                    micSub3.hidden = true;
                    micSub4.hidden = true;
                    micSub5.hidden = true;
                    break;
                case "subsection3-text-btn":
                    micSub3.src = "../mic-animate.gif";
                    micDescription.hidden = true;
                    micSub1.hidden = true;
                    micSub2.hidden = true;
                    micSub4.hidden = true;
                    micSub5.hidden = true;
                    break;
                case "subsection4-text-btn":
                    micSub4.src = "../mic-animate.gif";
                    micDescription.hidden = true;
                    micSub1.hidden = true;
                    micSub2.hidden = true;
                    micSub3.hidden = true;
                    micSub5.hidden = true;
                    break;
                case "subsection5-text-btn":
                    micSub5.src = "../mic-animate.gif";
                    micDescription.hidden = true;
                    micSub1.hidden = true;
                    micSub2.hidden = true;
                    micSub3.hidden = true;
                    micSub4.hidden = true;
                    break;
            }
        }
    }

}