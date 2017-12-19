using RestaurantReservation.BL.Concrete;
using RestaurantReservation.BL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.BL
{
    public class MealDateValidation : ValidationAttribute
    {
        private ServeListRepository serveRepository = new ServeListRepository();
        public override bool IsValid(object value)
        {

            /*DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
               "d MMM yyyy",
               CultureInfo.CurrentCulture,
               DateTimeStyles.None,
               out dateTime);*/
            if (value == null)
            {
                return false;
            }
            DateTime date = DateTime.Parse(value.ToString());
            bool notBookingFull = false;
            var serveListOnThisDate = serveRepository.GetServeListByDate(date);
            if (serveListOnThisDate != null)
            {
                if (serveListOnThisDate.AccumulatedTableOrdered < Constant.MealTimeChoice * Constant.TableAvailable)
                {
                    notBookingFull = true;
                }
            }
            else
            {
                notBookingFull = true;
            }


            return (notBookingFull && (date - DateTime.Now.Date).Days > Constant.MinDaysBeforeMeal);

        }
    }



}
