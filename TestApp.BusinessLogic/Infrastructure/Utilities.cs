namespace TestApp.BusinessLogic.Infrastructure
{
    public static class Utilities
    {
        /// <summary>
        /// Допустимые файлы для загрузки/скачивания
        /// </summary>
        /// <param name="extension">Расширение файла</param>
        /// <returns>Тип контента</returns>
        public static string ContentTypes(string extension) =>
            extension switch
            {
                ".txt" => "text/plain",
                ".css" => "text/css",
                ".html" => "text/html",
                ".rtf" => "text/rtf",
                ".xml" => "text/xml",
                ".svg" => "image/svg+xml",
                ".webp" => "image/webp",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".pdf" => "application/pdf",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".odt" => "application/vnd.oasis.opendocument.text",
                ".ods" => "application/vnd.oasis.opendocument.spreadsheet",
                _ => throw new System.NotImplementedException()
            };
    }
}
