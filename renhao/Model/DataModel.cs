using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace renhao.Model
{
    [BsonIgnoreExtraElements]
    public class DataModel
    {
        /// <summary>
        /// mongodbId
        /// </summary>
        public ObjectId Id { get; set; }
        /// <summary>
        /// 台站号
        /// </summary>
        public int StationCode { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }
        /// <summary>
        /// 观测场海拔高度
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Datetime { get; set; }
        /// <summary>
        /// 平均本站气压
        /// </summary>
        public double AverAirPressure { get; set; }
        /// <summary>
        /// 日最高本站气压
        /// </summary>
        public double MaxAirPressure { get; set; }
        /// <summary>
        /// 日最低本站气压
        /// </summary>
        public double MinAirPressure { get; set; }
        /// <summary>
        /// 平均气温
        /// </summary>
        public double AverTemperature { get; set; }
        /// <summary>
        /// 日最高气温
        /// </summary>
        public double MaxTemperature { get; set; }
        /// <summary>
        /// 日最低气温
        /// </summary>
        public double MinTemperature { get; set; }
        /// <summary>
        /// 平均相对湿度
        /// </summary>
        public int AverRelativeHumidity { get; set; }
        /// <summary>
        /// 最小相对湿度(仅自己）
        /// </summary>
        public int MixRRelativeHumidity { get; set; }
        /// <summary>
        /// 20-8时降水量
        /// </summary>
        public double Precipitation208 { get; set; }
        /// <summary>
        /// 8-20时降水量
        /// </summary>
        public double Precipitation820 { get; set; }
        /// <summary>
        /// 20-20时累计降水量
        /// </summary>
        public double Precipitation2020 { get; set; }
        /// <summary>
        /// 小型蒸发量
        /// </summary>
        public double SmallEvaporation { get; set; }
        /// <summary>
        /// 大型蒸发量
        /// </summary>
        public double BigEvaporation { get; set; }
        /// <summary>
        /// 平均风速
        /// </summary>
        public double AverWindSpeed { get; set; }
        /// <summary>
        /// 最大风速
        /// </summary>
        public double MaxWindSpeed { get; set; }
        /// <summary>
        /// 最大风速风向
        /// </summary>
        public string MaxWindSpeedDirection { get; set; }
        /// <summary>
        /// 极大风速
        /// </summary>
        public double VeryBigWindSpeed { get; set; }
        /// <summary>
        /// 极大风速风向
        /// </summary>
        public string VeryBigWindSpeedDirection { get; set; }
        /// <summary>
        /// 日照时数
        /// </summary>
        public double SunshineTime { get; set; }
        /// <summary>
        /// 平均地表气温
        /// </summary>
        public double AverGroundSufaceTemperature { get; set; }
        /// <summary>
        /// 日最高地表气温
        /// </summary>
        public double MaxGroundSufaceTemperature { get; set; }
        /// <summary>
        /// 日最低地表气温
        /// </summary>
        public double MinGroundSufaceTemperature { get; set; }

        public string FileName { get; set; }

        public DataModel(string data, string fileName)
        {
            this.FileName = fileName;
            var strs = new Regex("[\\s]+").Replace(data, " ").Split(' ');
            StationCode = Convert.ToInt32(strs[0]);
            Lat = Convert.ToDouble(strs[1]) / 100;
            Lng = Convert.ToDouble(strs[2]) / 100;
            Height = Convert.ToDouble(strs[3]) / 10;
            Datetime = Convert.ToDateTime(strs[4] + "-" + strs[5] + "-" + strs[6]);
            if (this.FileName.Contains("PRS-10004"))
            {
                //气压  PRS-10004
                AverAirPressure = Convert.ToDouble(strs[7]) / 10;
                MaxAirPressure = Convert.ToDouble(strs[8]) / 10;
                MinAirPressure = Convert.ToDouble(strs[9]) / 10;
            }
            else if (this.FileName.Contains("TEM-12001"))
            {
                //气温  TEM-12001
                AverTemperature = Convert.ToDouble(strs[7]) / 10;
                MaxTemperature = Convert.ToDouble(strs[8]) / 10;
                MinTemperature = Convert.ToDouble(strs[9]) / 10;
            }
            else if (this.FileName.Contains("RHU-13003"))
            {
                //相对湿度 RHU-13003
                AverRelativeHumidity = Convert.ToInt32(strs[7]) / 10;
                MixRRelativeHumidity = Convert.ToInt32(strs[8]) / 10;
            }
            else if (this.FileName.Contains("PRE-13011"))
            {
                //降水  PRE-13011
                Precipitation208 = Convert.ToDouble(strs[7]) / 10;
                Precipitation820 = Convert.ToDouble(strs[8]) / 10;
                Precipitation2020 = Convert.ToDouble(strs[9]) / 10;
            }
            else if (this.FileName.Contains("EVP-13240"))
            {
                //蒸发  EVP-13241
                SmallEvaporation = Convert.ToDouble(strs[7]) / 10;
                BigEvaporation = Convert.ToDouble(strs[8]) / 10;
            }
            else if (this.FileName.Contains("WIN-11002"))
            {
                //风向风速  WIN-11002
                AverWindSpeed = Convert.ToDouble(strs[7]) / 10;
                MaxWindSpeed = Convert.ToDouble(strs[8]) / 10;
                MaxWindSpeedDirection = WindDirection[Convert.ToInt32(strs[9])];
                VeryBigWindSpeed = Convert.ToDouble(strs[10]) / 10;
                VeryBigWindSpeedDirection = WindDirection[Convert.ToInt32(strs[11])];
            }
            else if (this.FileName.Contains("SSD-14032"))
            {
                //日照时数  SSD-14032
                SunshineTime = Convert.ToDouble(strs[7]) / 10;
            }
            else if (this.FileName.Contains("GST-12030-0cm"))
            {
                //0cm地温  GST-12030-0cm
                AverGroundSufaceTemperature = Convert.ToDouble(strs[7]) / 10;
                MaxGroundSufaceTemperature = Convert.ToDouble(strs[8]) / 10;
                MinGroundSufaceTemperature = Convert.ToDouble(strs[9]) / 10;
            }
        }

        /// <summary>
        /// 风向
        /// </summary>
        private static List<string> WindDirection = new List<string>()
        {
            "N",
            "NNE",
            "NE",
            "ENE",
            "E",
            "ESE",
            "SE",
            "SSE",
            "S",
            "SSW",
            "SW",
            "WSW",
            "W",
            "WNW",
            "NW",
            "NNW",
            "C"
        };
    }
}
