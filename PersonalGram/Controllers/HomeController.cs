using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Web.Mvc;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;
using PersonalGram.Models;
using PersonalGram.Models.Context;

namespace PersonalGram.Controllers
{
    public class HomeController : Controller
    {
        UserContext _userContext = new UserContext();

        public ActionResult Index()
        {
            //PlayGround playGround = new PlayGround();
            //playGround.StonesAndJewelry("acb", "aabbccd");
            //playGround.StonesAndJewelry();
            
            
            string jsonString = @"{
            'SPUTNIK' : {
                '/SPUTNIK/': {
                    'sputnik_rw': {
                        'FTP': {
                            'quota':'1073741824',
                            'deletedir':1,
                            'cur_size':'4096',
                            'rename':1,
                            'view':1,
                            'makedir':1,
                            'read':1,
                            'delete':1,
                            'write':1
                        }
                    },
                    'sputnik': {
                        'quota':'1073741824',
                        'makedir':1,
                        'cur_size':'4096',
                        'write':1
                    }
                }
            }}";
            //Resource resource = Newtonsoft.Json.JsonConvert.DeserializeObject<Resource>(jsonString);
            var resource = JsonConvert.DeserializeObject<ResourceCollection>(jsonString);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Experiment()
        {
            return View();
        }

        public ActionResult GetFile()
        {
            string path = ConfigurationManager.AppSettings["Photo"];
            string path2 = ConfigurationManager.AppSettings["Photo2"];
            var fileData = System.IO.File.ReadAllBytes(path);
            var anotherFileData = System.IO.File.ReadAllBytes(path2);
            
            byte[] zipData;
            byte[][] filesData = new byte[2][];
            filesData[0] = fileData;
            filesData[1] = anotherFileData;

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    
                    for (var i = 0; i < filesData.Length; i++)
                    {
                        var demoFile = archive.CreateEntry($"Photo{i}.jpg");
                        using (var entryStream = demoFile.Open())
                        using (var streamWriter = new BinaryWriter(entryStream))
                        {
                            streamWriter.Write(filesData[i]);
                        }
                    }
                }

                zipData = memoryStream.ToArray();
            }
            

            Response.ContentType = "image/zip";
            Response.AppendHeader("Content-Disposition", "attachment; filename=SailBig.zip");
            Response.BinaryWrite(zipData);
            Response.End();
            return Content("Ok");
        }
    }
}