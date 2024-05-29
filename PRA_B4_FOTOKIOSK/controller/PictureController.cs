using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class PictureController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }


        // De lijst met fotos die we laten zien
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();


        // Start methode die wordt aangeroepen wanneer de foto pagina opent.
        public void Start()
        {

            var now = DateTime.Now;
            int day = (int)now.DayOfWeek;
            string dateTime = "";
            if (day == 0)
            {
                dateTime = "0_Zondag";
            }
            if (day == 1)
            {
                dateTime = "1_Maandag";
            }
            if (day == 2)
            {
                dateTime = "2_Dinsdag";
            }
            if (day == 3)
            {
                dateTime = "3_Woensdag";
            }
            if (day == 4)
            {
                dateTime = "4_Donderdag";
            }
            if (day == 5)
            {
                dateTime = "5_Vrijdag";
            }
            if (day == 6)
            {
                dateTime = "6_Zaterdag";
            }


            // Initializeer de lijst met fotos
            // WAARSCHUWING. ZONDER FILTER LAADT DIT ALLES!
            // foreach is een for-loop die door een array loopt
            foreach (string dir in Directory.GetDirectories($@"../../../fotos"))
            {
                /**
                 * dir string is de map waar de fotos in staan. Bijvoorbeeld:
                 * \fotos\0_Zondag
                 */
                if (dir.Split("\\").Last() == dateTime)
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        /**
                         * file string is de file van de foto. Bijvoorbeeld:
                         * \fotos\0_Zondag\10_05_30_id8824.jpg
                         */

                        PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
                    }
                }

            }

            // Update de fotos
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {

        }

    }
}
