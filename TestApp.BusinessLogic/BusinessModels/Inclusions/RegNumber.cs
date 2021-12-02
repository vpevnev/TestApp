using CsvHelper.Configuration.Attributes;
using System;

namespace TestApp.BusinessLogic.BusinessModels.Inclusions
{
    public class RegNumber
    {
        const int intKindLength = 12;

        [Ignore]
        /// <summary>
        /// Регион
        /// </summary>
        public short RegnCode { get; set; }

        [Ignore]
        /// <summary>
        /// Район
        /// </summary>
        public short DistCode { get; set; }

        [Ignore]
        /// <summary>
        /// Регистрационный номер
        /// </summary>
        public int InsrNumber { get; set; }

        /// <summary>
        /// Регистрационный номер полный
        /// </summary>
        public string FullRegNumber
        {
            set
            {
                if (value.Contains('-'))
                {
                    string[] splited = value.Split('-');

                    RegnCode = splited?[0].Length > 0 ? Convert.ToInt16(value.Split('-')[0]) : (short)0;
                    DistCode = splited?[1].Length > 0 ? Convert.ToInt16(value.Split('-')[1]) : (short)0;
                    InsrNumber = splited?[2].Length > 0 ? Convert.ToInt32(value.Split('-')[2]) : 0;
                }
                else
                {
                    value = value.PadLeft(intKindLength, '0');

                    RegnCode = Convert.ToInt16(value.Substring(0, 3));
                    DistCode = Convert.ToInt16(value.Substring(3, 3));
                    InsrNumber = Convert.ToInt32(value.Substring(6, 6));
                }
            }
            get
            {
                return ToString();
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public RegNumber() { }

        /// <summary>
        /// Регистрационный номер
        /// </summary>
        /// <param name="region">Номер региона</param>
        /// <param name="district">Номер района</param>
        /// <param name="number">Регистрационный номер</param>
        public RegNumber(object region, object district, object number)
        {
            RegnCode = Convert.ToInt16(region);
            DistCode = Convert.ToInt16(district);
            InsrNumber = Convert.ToInt32(number);
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="regNumber">000-000-000000</param>
        public RegNumber(string regNumber)
        {
            RegnCode = Convert.ToInt16(regNumber.Split('-')[0]);
            DistCode = Convert.ToInt16(regNumber.Split('-')[1]);
            InsrNumber = Convert.ToInt32(regNumber.Split('-')[2]);
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="number">Регистрационный номер</param>
        public RegNumber(long number)
        {
            string regNumber = string.Format("{0:000000000000}", number);
            RegnCode = short.Parse(regNumber.Substring(0, 3));
            DistCode = short.Parse(regNumber.Substring(3, 3));
            InsrNumber = int.Parse(regNumber[6..]);
        }

        /// <summary>
        /// Возвращение строкового представления регистрационного номера
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0:000}-{1:000}-{2:000000}", RegnCode, DistCode, InsrNumber);
        }

        /// <summary>
        /// Возвращение целого номера
        /// </summary>
        /// <returns></returns>
        public long ToInt()
        {
            return (long)RegnCode * (long)1000000000 + (long)DistCode * (long)1000000 + (long)InsrNumber;
        }
    }
}
