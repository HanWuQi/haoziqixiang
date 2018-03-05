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
        public string Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng { get; set; }
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
        public string AverAirPressure { get; set; }
        /// <summary>
        /// 日最高本站气压
        /// </summary>
        public string MaxAirPressure { get; set; }
        /// <summary>
        /// 日最低本站气压
        /// </summary>
        public string MinAirPressure { get; set; }
        /// <summary>
        /// 平均气温
        /// </summary>
        public string AverTemperature { get; set; }
        /// <summary>
        /// 日最高气温
        /// </summary>
        public string MaxTemperature { get; set; }
        /// <summary>
        /// 日最低气温
        /// </summary>
        public string MinTemperature { get; set; }
        /// <summary>
        /// 平均相对湿度
        /// </summary>
        public string AverRelativeHumidity { get; set; }
        /// <summary>
        /// 最小相对湿度(仅自己）
        /// </summary>
        public string MixRRelativeHumidity { get; set; }
        /// <summary>
        /// 20-8时降水量
        /// </summary>
        public string Precipitation208 { get; set; }
        /// <summary>
        /// 8-20时降水量
        /// </summary>
        public string Precipitation820 { get; set; }
        /// <summary>
        /// 20-20时累计降水量
        /// </summary>
        public string Precipitation2020 { get; set; }
        /// <summary>
        /// 小型蒸发量
        /// </summary>
        public string SmallEvaporation { get; set; }
        /// <summary>
        /// 大型蒸发量
        /// </summary>
        public string BigEvaporation { get; set; }
        /// <summary>
        /// 平均风速
        /// </summary>
        public string AverWindSpeed { get; set; }
        /// <summary>
        /// 最大风速
        /// </summary>
        public string MaxWindSpeed { get; set; }
        /// <summary>
        /// 最大风速风向
        /// </summary>
        public string MaxWindSpeedDirection { get; set; }
        /// <summary>
        /// 极大风速
        /// </summary>
        public string VeryBigWindSpeed { get; set; }
        /// <summary>
        /// 极大风速风向
        /// </summary>
        public string VeryBigWindSpeedDirection { get; set; }
        /// <summary>
        /// 日照时数
        /// </summary>
        public string SunshineTime { get; set; }
        /// <summary>
        /// 平均地表气温
        /// </summary>
        public string AverGroundSufaceTemperature { get; set; }
        /// <summary>
        /// 日最高地表气温
        /// </summary>
        public string MaxGroundSufaceTemperature { get; set; }
        /// <summary>
        /// 日最低地表气温
        /// </summary>
        public string MinGroundSufaceTemperature { get; set; }

        public string FileName { get; set; }

        public DataModel(string data, string fileName)
        {
            this.FileName = fileName;
            var strs = new Regex("[\\s]+").Replace(data, " ").Split(' ');
            StationCode = Convert.ToInt32(strs[0]);
            Lat = strs[1];
            Lng = strs[2];
            Height = Convert.ToDouble(strs[3]) / 10;
            Datetime = Convert.ToDateTime(strs[4] + "-" + strs[5] + "-" + strs[6]);
            
            if (this.FileName.Contains("PRS-10004"))
            {
                //气压  PRS-10004
                AverAirPressure = strs[7];
                MaxAirPressure = strs[8];
                MinAirPressure = strs[9];
            }
            else if (this.FileName.Contains("TEM-12001"))
            {
                //气温  TEM-12001
                AverTemperature = strs[7];
                MaxTemperature = strs[8];
                MinTemperature = strs[9];
            }
            else if (this.FileName.Contains("RHU-13003"))
            {
                //相对湿度 RHU-13003
                AverRelativeHumidity = strs[7];
                MixRRelativeHumidity = strs[8];
            }
            else if (this.FileName.Contains("PRE-13011"))
            {
                //降水  PRE-13011
                Precipitation208 = strs[7];
                Precipitation820 = strs[8];
                Precipitation2020 = strs[9];
            }
            else if (this.FileName.Contains("EVP-13240"))
            {
                //蒸发  EVP-13241
                SmallEvaporation = strs[7];
                BigEvaporation = strs[8];
            }
            else if (this.FileName.Contains("WIN-11002"))
            {
                //风向风速  WIN-11002
                AverWindSpeed = strs[7];
                MaxWindSpeed = strs[8];
                MaxWindSpeedDirection = strs[9];
                VeryBigWindSpeed = strs[10];
                VeryBigWindSpeedDirection = strs[11];
            }
            else if (this.FileName.Contains("SSD-14032"))
            {
                //日照时数  SSD-14032
                SunshineTime = strs[7];
            }
            else if (this.FileName.Contains("GST-12030-0cm"))
            {
                //0cm地温  GST-12030-0cm
                AverGroundSufaceTemperature = strs[7];
                MaxGroundSufaceTemperature = strs[8];
                MinGroundSufaceTemperature = strs[9];
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
