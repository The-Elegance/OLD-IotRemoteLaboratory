let consolewrapper = {};

consolewrapper.writeLine = function writeLine(str) {
    console.log(str);
}

window.consolewrapper = consolewrapper;