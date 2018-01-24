using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renhao.Model
{
    public class MongoDBHelper
    {
        static MongoClient client = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase database = client.GetDatabase("renhao");

        public static void UpsertDataModel(List<DataModel> list)
        {
            var collection = database.GetCollection<DataModel>("qixiang");
            UpdateOptions updateOptions = new UpdateOptions();
            updateOptions.IsUpsert = false;
            list.ForEach(x =>
            {
                if (x.FileName.Contains("PRS-10004"))
                {
                    //气压  PRS-10004
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                        Builders<DataModel>.Update
                                                                            .Set(s => s.AverAirPressure, x.AverAirPressure)
                                                                            .Set(s => s.MaxAirPressure, x.MaxAirPressure)
                                                                            .Set(s => s.MinAirPressure, x.MinAirPressure),
                                                        updateOptions);
                    }
                }
                else if (x.FileName.Contains("TEM-12001"))
                {
                    //气温  TEM-12001
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                    Builders<DataModel>.Update
                                                                        .Set(s => s.AverTemperature, x.AverTemperature)
                                                                        .Set(s => s.MaxTemperature, x.MaxTemperature)
                                                                        .Set(s => s.MinTemperature, x.MinTemperature),
                                                    updateOptions);
                    }
                }
                else if (x.FileName.Contains("RHU-13003"))
                {
                    //相对湿度 RHU-13003
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                    Builders<DataModel>.Update
                                                                        .Set(s => s.AverRelativeHumidity, x.AverRelativeHumidity)
                                                                        .Set(s => s.MixRRelativeHumidity, x.MixRRelativeHumidity),
                                                    updateOptions);
                    }
                }
                else if (x.FileName.Contains("PRE-13011"))
                {
                    //降水  PRE-13011
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                    Builders<DataModel>.Update
                                                                        .Set(s => s.Precipitation208, x.Precipitation208)
                                                                        .Set(s => s.Precipitation820, x.Precipitation820)
                                                                        .Set(s => s.Precipitation2020, x.Precipitation2020),
                                                    updateOptions);
                    }
                }
                else if (x.FileName.Contains("EVP-13240"))
                {
                    //蒸发  EVP-13241
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                   Builders<DataModel>.Update
                                                                       .Set(s => s.SmallEvaporation, x.SmallEvaporation)
                                                                       .Set(s => s.BigEvaporation, x.BigEvaporation),
                                                   updateOptions);
                    }
                }
                else if (x.FileName.Contains("WIN-11002"))
                {
                    //风向风速  WIN-11002
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                   Builders<DataModel>.Update
                                                                       .Set(s => s.AverWindSpeed, x.AverWindSpeed)
                                                                       .Set(s => s.MaxWindSpeed, x.MaxWindSpeed)
                                                                       .Set(s => s.MaxWindSpeedDirection, x.MaxWindSpeedDirection)
                                                                       .Set(s => s.VeryBigWindSpeed, x.VeryBigWindSpeed)
                                                                       .Set(s => s.VeryBigWindSpeedDirection, x.VeryBigWindSpeedDirection),
                                                   updateOptions);
                    }
                }
                else if (x.FileName.Contains("SSD-14032"))
                {
                    //日照时数  SSD-14032
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                   Builders<DataModel>.Update
                                                                       .Set(s => s.SunshineTime, x.SunshineTime),
                                                   updateOptions);
                    }
                }
                else if (x.FileName.Contains("GST-12030-0cm"))
                {
                    //0cm地温  GST-12030-0cm
                    var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    if (temp == null)
                    {
                        collection.InsertOne(x);
                    }
                    else
                    {
                        collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                                                    Builders<DataModel>.Update
                                                                        .Set(s => s.AverGroundSufaceTemperature, x.AverGroundSufaceTemperature)
                                                                        .Set(s => s.MaxGroundSufaceTemperature, x.MaxGroundSufaceTemperature)
                                                                        .Set(s => s.MinGroundSufaceTemperature, x.MinGroundSufaceTemperature),
                                                    updateOptions);
                    }
                }
            });
        }
    }
}
