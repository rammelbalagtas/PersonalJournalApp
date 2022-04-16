
// Test browser support
window.SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition || null;

if (window.SpeechRecognition === null) {

}

else {

    var subsectionText1 = document.getElementById('SubsectionText1');
    var subsection1Btn = document.getElementById('subsection1-text-btn');
    var micImage1 = document.getElementById('mic1-img');

    var subsectionText2 = document.getElementById('SubsectionText2');
    var subsection2Btn = document.getElementById('subsection2-text-btn');
    var micImage2 = document.getElementById('mic2-img');

    var recognizing;
    var isInterim;
    var temp;

    var recognizer = new window.SpeechRecognition();
    recognizer.continuous = true;
    recognizer.interimResults = true;
    reset();

    recognizer.onresult = function (event) {

        // old code
        //var subsectionText = document.activeElement;
        //for (var i = event.resultIndex; i < event.results.length; ++i) {
        //    if (event.results[i].isFinal) {
        //        subsectionText1.value += event.results[i][0].transcript;
        //    }
        //}

        var interim_transcript = "";

        if (!isInterim) {
            temp = subsectionText1.value; //transfer current value to a temp variable
            isInterim = true //start interim recognition
        }

        //once recognition is final, move back the previous value and append the final transcript
        if (event.results[event.resultIndex].isFinal) {
            isInterim = false;
            subsectionText1.value = temp;
        }

        for (var i = event.resultIndex; i < event.results.length; ++i) {
            if (event.results[i].isFinal) {
                subsectionText1.value += event.results[i][0].transcript;
            } else {
                 interim_transcript += event.results[i][0].transcript;
            }
        }

        //while interim recognition is running, keep replacing the subtext value with 
        //interim transcript
        if (isInterim) {
            subsectionText1.value = temp + interim_transcript;
        }

    }

    subsection1Btn.addEventListener('click', function () {
        //toggle between start and stop
        if (recognizing) {
            recognizer.stop();
            reset();
        } else {
            recognizer.start();
            recognizing = true;
            micImage1.src = "../mic-animate.gif";
        }
    });

    function reset() {
        recognizing = false;
        micImage1.src = "../mic.gif";
    }

}