let monacoInterop = {};
monacoInterop.editors = {};

monacoInterop.initialize = function initialize(elementId, initialCode, language, dotnetHelper) {
    require.config({ paths: { 'vs': 'js/monaco-editor/min/vs', 'esm-vs': 'js/monaco-editor/esm/vs/' } });
    require(['vs/editor/editor.main'], function initializeEditor() {
        var editor = monaco.editor.create(document.getElementById(elementId), {
            value: initialCode,
            domReadOnly: true,
            language: language,
            automaticLayout: true
        });

        editor.onDidChangeModelContent(() => {
            dotnetHelper.invokeMethodAsync('OnCodeChanged', monacoInterop.editors[elementId].getValue());

            // trying get MessageControoler
            //const editor = monacoInterop.editors[elementId];
            //var msgController = MessageController.get(editor);

            //if (msgController && editor.hasModel())
            //{
            //    let message = this.editor.getOptions().get(91 /* EditorOption.readOnlyMessage */);
            //    if (!message) {
            //        if (this.editor.isSimpleWidget) {
            //            message = new MarkdownString(nls.localize('editor.simple.readonly', "Kkk"));
            //        }
            //        else {
            //            message = new MarkdownString(nls.localize('editor.readonly', "mmsd"));
            //        }
            //    }
            //    messageController.showMessage(message, this.editor.getPosition());
            //}

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

monacoInterop.readonlyMode = function readonlyMode(elementId, state)
{
    var position = {
        lineNumber: 1,
        column: 1,
    };

    monacoInterop.editors[elementId].updateOptions({ readOnly: state });
}

monacoInterop.changeFontSize = function changeFontSize(elementId, fontSize)
{
    monacoInterop.editors[elementId].updateOptions({ fontSize: fontSize });
}

window.monacoInterop = monacoInterop;
