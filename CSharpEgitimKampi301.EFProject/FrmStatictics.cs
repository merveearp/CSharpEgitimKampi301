using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatictics : Form
    {
        public FrmStatictics()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatictics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Location.Count().ToString();
            lblAverageCapacity.Text = db.Location.Average(x => x.Capacity).ToString();
            lblAvgTourPrice.Text = db.Location.Average(x => x.Price).ToString() + "₺";
            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();
            lblTourCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkeyAvgCapacity.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var guideId = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblGuideNameRoma.Text = db.Guide.Where(x => x.GuideId == guideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacity.Text = db.Location.Where(y => y.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();
            var maxPriceTour = db.Location.Max(x => x.Price);
            lblMaxPriceTour.Text = db.Location.Where(x => x.Price == maxPriceTour).Select(y => y.City).FirstOrDefault().ToString();
            var guideIdByHakan = db.Guide.Where(x => x.GuideName == "Hakan" && x.GuideSurname == "Kaya").Select(y => y.GuideId).FirstOrDefault();
            lblGuideHakanLocation.Text = db.Location.Where(x => x.GuideId == guideIdByHakan).Count().ToString();


        }
    }

}
