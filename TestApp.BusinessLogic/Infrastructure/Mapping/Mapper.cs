using AutoMapper;
using ExcelMapper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApp.BusinessLogic.Infrastructure.Mapping
{
    public static class Mapper
    {
        private static readonly Profile profile = new MappingProfile();

        /// <summary>
        /// Выполняет сопоставление исходного объекта с новым целевым объектом
        /// </summary>
        /// <typeparam name="TSource">Тип исходного объекта</typeparam>
        /// <typeparam name="TDestination">Тип целевого объекта</typeparam>
        /// <param name="source">Исходный объект</param>
        /// <param name="destination">Целевой объект</param>
        public static void Map<TSource, TDestination>(TSource source, out TDestination destination)
        {
            var configuration = new MapperConfiguration(c => { c.AddProfile(profile); });
            var mapper = configuration.CreateMapper();

            destination = mapper.Map<TSource, TDestination>(source);
        }

        ///// <summary>
        ///// Выполняет сопоставление исходного объекта с новым целевым объектом.
        ///// Перегрузка устарела. Воспользуйтесь перегрузкой с выходным параметром
        ///// </summary>
        ///// <typeparam name="TSource">Тип исходного объекта</typeparam>
        ///// <typeparam name="TDestination">Тип целевого объекта</typeparam>
        ///// <param name="source">Исходный объект</param>
        ///// <returns>Целевой объект</returns>
        //[Obsolete("Данная перегрузка устарела. Воспользуйтесь перегрузкой с выходным параметром", false)]
        //public static TDestination Map<TSource, TDestination>(TSource source)
        //{
        //    var configuration = new MapperConfiguration(c => { c.AddProfile(profile); });
        //    var mapper = configuration.CreateMapper();
        //    var destination = mapper.Map<TSource, TDestination>(source);

        //    return destination;
        //}

        /// <summary>
        /// Выполняет сопоставление файла excel с аналогичным классом DTO
        /// </summary>
        /// <typeparam name="TDestination">Тип назначения</typeparam>
        /// <param name="filePath">Путь к исходному файлу</param>
        /// <returns>Коллекция объектов</returns>
        public static IEnumerable<TDestination> ExcelMapToObject<TDestination>(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using var stream = File.OpenRead(filePath);
            using var importer = new ExcelImporter(stream);
            {
                ExcelSheet sheet = importer.ReadSheet();
                IEnumerable<TDestination> result = sheet.ReadRows<TDestination>().ToList();

                return result;
            }
        }

        /// <summary>
        /// Выполняет сопоставление файла excel с аналогичным классом DTO на основе карты соответствия
        /// </summary>
        /// <typeparam name="TDestination">Тип назначения</typeparam>
        /// <typeparam name="TMap">Карта сопоставления</typeparam>
        /// <param name="filePath">Путь к исходному файлу</param>
        /// <returns>Коллекция объектов</returns>
        public static IEnumerable<TDestination> ExcelMapToObject<TDestination, TMap>(string filePath, int headingIndex = default) where TMap : ExcelClassMap, new()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using var stream = File.OpenRead(filePath);
            using var importer = new ExcelImporter(stream);
            {
                importer.Configuration.RegisterClassMap<TMap>();

                ExcelSheet sheet = importer.ReadSheet();
                sheet.HeadingIndex = headingIndex;

                IEnumerable<TDestination> result = sheet.ReadRows<TDestination>().ToList();

                return result;
            }
        }

        /// <summary>
        /// Выполняет сопоставление файла excel с аналогичным классом DTO на основе карты соответствия
        /// </summary>
        /// <typeparam name="TDestination">Тип назначения</typeparam>
        /// <typeparam name="TMap">Карта сопоставления</typeparam>
        /// <param name="stream">Последовательность байтов</param>
        /// <returns>Коллекция объектов</returns>
        public static IEnumerable<TDestination> ExcelMapToObject<TDestination, TMap>(Stream stream, int headingIndex = default) where TMap : ExcelClassMap, new()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using var importer = new ExcelImporter(stream);
            {
                importer.Configuration.RegisterClassMap<TMap>();

                ExcelSheet sheet = importer.ReadSheet();
                sheet.HeadingIndex = headingIndex;

                try
                {
                    IEnumerable<TDestination> result = sheet.ReadRows<TDestination>().ToList();
                    
                    return result;
                }
                catch(ExcelMappingException exception)
                {
                    throw new ExcelMappingException($"Не удалось прочитать данные из файла. {exception.Message}");
                }
            }
        }
    }
}
