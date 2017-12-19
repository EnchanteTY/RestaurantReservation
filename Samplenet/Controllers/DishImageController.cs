using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.Controllers
{
    public class DishImageController : Controller
    {
        private IDishImageRepository imageRepository;

        public DishImageController()
        {

        }

        public DishImageController(IDishImageRepository repository)
        {
            this.imageRepository = repository;
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {
            bool allValid = true;
            string inValidFiles = "";

            if (files[0] != null)
            {

                if (files.Length <= 4)
                {

                    foreach (var file in files)
                    {
                        if (!ValidateFile(file))
                        {
                            allValid = false;
                            inValidFiles += ", " + file.FileName;
                        }
                    }

                    if (allValid)
                    {
                        foreach (var file in files)
                        {
                            try
                            {
                                SaveFileToDisk(file);
                            }
                            catch (System.Exception)
                            {
                                ModelState.AddModelError("FileName", "Sorry an error occurred saving the files to disk, please try again");
                            }
                        }
                    }
                    //else add an error listing out the invalid files            
                    else
                    {
                        ModelState.AddModelError("FileName", "All files must be gif, png, jpeg or jpg  and less than 2MB in size.The following files" + inValidFiles +
                            " are not valid");
                    }
                }
                //the user has entered more than 10 files
                else
                {
                    ModelState.AddModelError("FileName", "Please only upload up to ten files at a time");
                }
            }
            else
            {
                //if the user has not entered a file return an error message
                ModelState.AddModelError("FileName", "Please choose a file");
            }

            if (ModelState.IsValid)
            {
                bool duplicates = false;
                bool otherDbError = false;
                string duplicateFiles = "";
                foreach (var file in files)
                {
                    //try and save each file
                    var image = new DishImage { FileName = file.FileName };


                    imageRepository.SaveImage(image);

                    //if there is an exception check if it is caused by a duplicate file

                }
                //add a list of duplicate files to the error message
                if (duplicates)
                {
                    ModelState.AddModelError("FileName", "All files uploaded except the files" + duplicateFiles + ", which already exist in the system." +
                        " Please delete them and try again if you wish to re-add them");
                    return View();
                }
                else if (otherDbError)
                {
                    ModelState.AddModelError("FileName", "Sorry an error has occurred saving to the database, please try again");
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        private bool ValidateFile(HttpPostedFileBase file)
        {
            string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            string[] allowedFileTypes = { ".gif", ".png", ".jpeg", ".jpg" };
            if ((file.ContentLength > 0 && file.ContentLength < 2097152) && allowedFileTypes.Contains(fileExtension))
            {
                return true;
            }
            return false;
        }

        private void SaveFileToDisk(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width != 200 || img.Height != 150)
            {
                img.Resize(200, 150);
            }
            img.Save(Constant.Constant.DishImagePath + file.FileName);
            if (img.Width > 100)
            {
                img.Resize(100, img.Height);
            }
            img.Save(Constant.Constant.DishThumbnailPath + file.FileName);
        }
    }
}