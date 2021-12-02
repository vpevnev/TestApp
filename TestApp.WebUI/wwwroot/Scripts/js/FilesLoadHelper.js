/*
 * Вспомогательный скрипт
 * для элементов формы загрузки файлов
 */

let styleFilesLabel = document.head.appendChild(document.createElement("style"));
styleFilesLabel.innerHTML = "#filesLabel:after { content: 'Обзор' }";

$(".custom-file-input").on("change", function () {
    var files = Array.from(this.files);

    let needValidateFilesSize = $("#needValidateFilesSize").html();

    if (!needValidateFilesSize || validateFilesSize(files)) {
        var text = files[0].name;

        if (files.length > 1)
            text = `Выбрано ${files.length} файла(ов).`;

        $(this).siblings(".custom-file-label").html(text);
    }
});

function validateFilesSize(files) {
    let result = true;

    files.forEach(function (file) {
        const fileSize = file.size / 1024 / 1024; // в Мб

        console.log(`This ${file.name} size is: ${fileSize}`);

        if (fileSize > 5) {
            alert(`Файл ${file.name} превышает 5 Мб!`);
            $(".custom-file-input").val('');
            $(".custom-file-label").html('Выберите файлы для загрузки');

            result = false;
        }
    });

    return result;
};

$('#loadButton').click(function () {
    let validForm = document.getElementById('loadForm').checkValidity();

    if (validForm) {
        let _this = $(this);

        _this
            .prop('disabled', true)
            .find('.spinner-border').removeClass('d-none');

        document.getElementById('loadForm').submit();
    }
});