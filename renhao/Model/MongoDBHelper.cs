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
        public static IMongoCollection<DataModel> collection { get; set; }
        
        public static IMongoCollection<DataModel> GetCollection()
        {
            if(collection!=null)
            {
                return collection;
            }
            else
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("renhao");
                collection = database.GetCollection<DataModel>("qixiang");
                return collection;
            }
        }



        public static void UpsertDataModel(List<DataModel> list)
        {
            var collection = GetCollection();
            UpdateOptions updateOptions = new UpdateOptions();
            updateOptions.IsUpsert = true;

            var models = new List<WriteModel<DataModel>>();

            foreach(var x in list)
            {
                if (x.FileName.Contains("PRS-10004"))
                {
                    //气压  PRS-10004
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                                Builders<DataModel>.Update
                    //                                                    .Set(s => s.AverAirPressure, x.AverAirPressure)
                    //                                                    .Set(s => s.MaxAirPressure, x.MaxAirPressure)
                    //                                                    .Set(s => s.MinAirPressure, x.MinAirPressure),
                    //                                updateOptions);

                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.AverAirPressure, x.AverAirPressure)
                                            .Set(s => s.MaxAirPressure, x.MaxAirPressure)
                                            .Set(s => s.MinAirPressure, x.MinAirPressure))
                    {  IsUpsert = true });
                    //}
                }
                else if (x.FileName.Contains("TEM-12001"))
                {
                    //气温  TEM-12001
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                            Builders<DataModel>.Update
                    //                                                .Set(s => s.AverTemperature, x.AverTemperature)
                    //                                                .Set(s => s.MaxTemperature, x.MaxTemperature)
                    //                                                .Set(s => s.MinTemperature, x.MinTemperature),
                    //                            updateOptions);
                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.AverTemperature, x.AverTemperature)
                                            .Set(s => s.MaxTemperature, x.MaxTemperature)
                                            .Set(s => s.MinTemperature, x.MinTemperature))
                    { IsUpsert = true });
                    //}
                }
                else if (x.FileName.Contains("RHU-13003"))
                {
                    //相对湿度 RHU-13003
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                            Builders<DataModel>.Update
                    //                                                .Set(s => s.AverRelativeHumidity, x.AverRelativeHumidity)
                    //                                                .Set(s => s.MixRRelativeHumidity, x.MixRRelativeHumidity),
                    //                            updateOptions);

                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.AverRelativeHumidity, x.AverRelativeHumidity)
                                            .Set(s => s.MixRRelativeHumidity, x.MixRRelativeHumidity))
                    { IsUpsert = true });
                    //}
                }
                else if (x.FileName.Contains("PRE-13011"))
                {
                    //降水  PRE-13011
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                            Builders<DataModel>.Update
                    //                                                .Set(s => s.Precipitation208, x.Precipitation208)
                    //                                                .Set(s => s.Precipitation820, x.Precipitation820)
                    //                                                .Set(s => s.Precipitation2020, x.Precipitation2020),
                    //                            updateOptions);

                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.Precipitation208, x.Precipitation208)
                                            .Set(s => s.Precipitation820, x.Precipitation820)
                                            .Set(s => s.Precipitation2020, x.Precipitation2020))
                    { IsUpsert = true });
                    //}
                }
                else if (x.FileName.Contains("EVP-13240"))
                {
                    //蒸发  EVP-13241
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                            Builders<DataModel>.Update
                    //                                                .Set(s => s.SmallEvaporation, x.SmallEvaporation)
                    //                                                .Set(s => s.BigEvaporation, x.BigEvaporation),
                    //                            updateOptions);

                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.SmallEvaporation, x.SmallEvaporation)
                                            .Set(s => s.BigEvaporation, x.BigEvaporation))
                    { IsUpsert = true });
                    //}
                }
                else if (x.FileName.Contains("WIN-11002"))
                {
                    //风向风速  WIN-11002
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                            Builders<DataModel>.Update
                    //                                                .Set(s => s.AverWindSpeed, x.AverWindSpeed)
                    //                                                .Set(s => s.MaxWindSpeed, x.MaxWindSpeed)
                    //                                                .Set(s => s.MaxWindSpeedDirection, x.MaxWindSpeedDirection)
                    //                                                .Set(s => s.VeryBigWindSpeed, x.VeryBigWindSpeed)
                    //                                                .Set(s => s.VeryBigWindSpeedDirection, x.VeryBigWindSpeedDirection),
                    //                            updateOptions);

                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.AverWindSpeed, x.AverWindSpeed)
                                            .Set(s => s.MaxWindSpeed, x.MaxWindSpeed)
                                            .Set(s => s.MaxWindSpeedDirection, x.MaxWindSpeedDirection)
                                            .Set(s => s.VeryBigWindSpeed, x.VeryBigWindSpeed)
                                            .Set(s => s.VeryBigWindSpeedDirection, x.VeryBigWindSpeedDirection))
                    { IsUpsert = true });
                    //}
                }
                else if (x.FileName.Contains("SSD-14032"))
                {
                    //日照时数  SSD-14032
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                            Builders<DataModel>.Update
                    //                                                .Set(s => s.SunshineTime, x.SunshineTime),
                    //                            updateOptions);

                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.SunshineTime, x.SunshineTime))
                    { IsUpsert = true });
                    //}
                }
                else if (x.FileName.Contains("GST-12030-0cm"))
                {
                    //0cm地温  GST-12030-0cm
                    //var temp = collection.Find<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime).FirstOrDefault();
                    //if (temp == null)
                    //{
                    //    collection.InsertOne(x);
                    //}
                    //else
                    //{
                    //collection.UpdateOne<DataModel>(s => s.StationCode == x.StationCode && s.Datetime == x.Datetime,
                    //                            Builders<DataModel>.Update
                    //                                                .Set(s => s.AverGroundSufaceTemperature, x.AverGroundSufaceTemperature)
                    //                                                .Set(s => s.MaxGroundSufaceTemperature, x.MaxGroundSufaceTemperature)
                    //                                                .Set(s => s.MinGroundSufaceTemperature, x.MinGroundSufaceTemperature),
                    //                            updateOptions);

                    models.Add(new UpdateOneModel<DataModel>(
                        Builders<DataModel>.Filter.And(Builders<DataModel>.Filter.Eq("StationCode", x.StationCode), Builders<DataModel>.Filter.Eq("Datetime", x.Datetime)),
                        Builders<DataModel>.Update.Set(s => s.Lng, x.Lng).Set(s => s.Lat, x.Lat).Set(s => s.Height, x.Height)
                                            .Set(s => s.AverGroundSufaceTemperature, x.AverGroundSufaceTemperature)
                                            .Set(s => s.MaxGroundSufaceTemperature, x.MaxGroundSufaceTemperature)
                                            .Set(s => s.MinGroundSufaceTemperature, x.MinGroundSufaceTemperature))
                    { IsUpsert = true });
                    //}
                }
            }
            collection.BulkWrite(models, new BulkWriteOptions { IsOrdered = false });
        }

        public static List<DataModel> GetData(int stationCode,DateTime startTime,DateTime endTime)
        {
            var res = 
                collection
                .Find(s => s.StationCode == stationCode && s.Datetime >= startTime && s.Datetime < endTime)
                .ToList();
            return res;
        }
    }
}
