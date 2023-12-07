let monacoInterop = {};
monacoInterop.editors = {};
monacoInterop.initialize = function initialize(elementId, initialCode, language, dotnetHelper) {
    require.config({ paths: { 'vs': 'monaco-editor/min/vs' } });
    require(['vs/editor/editor.main'], function initializeEditor() {
        var editor = monaco.editor.create(document.getElementById(elementId), {
            value: initialCode,
            language: language
        });

        editor.onDidChangeModelContent(() => {
            dotnetHelper.invokeMethodAsync('OnCodeChanged', monacoInterop.editors[elementId].getValue());
        });

        monacoInterop.editors[elementId] = editor;
    });
}

monacoInterop.getCode = function getCode(elementId) {
    return monacoInterop.editors[elementId].getValue();
}
monacoInterop.setCode = function setCode(elementId, code) {
    monacoInterop.editors[elementId].setValue(code);
}

window.monacoInterop = monacoInterop;
