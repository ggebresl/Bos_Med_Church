var audio, playbtn, seek_bar;
function initAudioPlayer() {
    audio = new Audio();
    audio.src = "";
    audio.loo = true;
    audio.play();
}