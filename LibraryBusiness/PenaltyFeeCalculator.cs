using System;
using System.Collections.Generic;
using System.Text;
using LibraryConfigUtilities;

namespace LibraryBusiness
{
    /* Description,
     * settingList member holds configuration parameters stored in the App.config file, 
     * please explore the properties and methods in the Country class to get a better understanding.
     * 
     * Please implement this class accordingly to accomplish requirements.
     * Feel free to add any parameters, methods, class members, etc. if necessary
     */
    public class PenaltyFeeCalculator{
        
        private List<Country> settingList = new LibrarySetting().LibrarySettingList;
        
        public PenaltyFeeCalculator() {
            
        }

        public String Calculate(DateTime startDate,DateTime endDate, string countryCode )
        {
            var totalDays = Convert.ToInt32((endDate - startDate).TotalDays);

            //Too old version for Linq
            var country = settingList.Find(p => p.CountryCode == countryCode);
            if(country ==  null)
            {
                //HandleExc Country Not Found
                return "exc";
            }
            else
            {
                //We need Weekend & holiday controls 
                var totalFee  = country.DailyPenaltyFee* totalDays;
                return totalFee.ToString();
            }
      
        }
    }
}
