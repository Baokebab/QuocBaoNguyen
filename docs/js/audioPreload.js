window.audioCache = {};

window.preloadAudio = (key, src) => {
    const audio = new Audio(src);
    audio.preload = "auto";
    audio.load();
    window.audioCache[key] = audio;
};

window.playPreloaded = (key) => {
    const audio = window.audioCache[key];
    if (audio) {
        audio.currentTime = 0;
        audio.play();
    }
};