editors = {};

function CreateEditor(editorId, defaultValue, height, isReadOnly, uploadUrl, dotNetReference) {
    ClassicEditor
        .create(document.getElementById(editorId), {
            simpleUpload: {
                uploadUrl: uploadUrl,
                headers: {"DocumentId": editorId}
            }
        })
        .then(editor => {
            editors[editorId] = editor;
            editor.setData(defaultValue);
            editor.editing.view.change(writer => {
                writer.setStyle('height', height, editor.editing.view.document.getRoot());
            });

            editor.model.document.on('change', () => {
                let data = editor.getData();
                console.log(data);
                dotNetReference.invokeMethodAsync('OnEditorChanged', data);
            });

            const toolbarElement = editor.ui.view.toolbar.element;

            if (isReadOnly) {
                toolbarElement.style.display = "none";
                editor.enableReadOnlyMode("lock");
            }
        })
        .catch(error => {
            console.error(error);
        });

}


function DestroyEditor(editorId) {
    editors[editorId]
        .destroy()
        .then(() => delete editors[editorId])
        .catch(error => console.log(error));
}