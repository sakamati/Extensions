using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReviewStats
{
    public partial class formCodeReviewStats : Form
    {
        internal static readonly string TeamProjectCollectionUrl;

        private IEnumerable<CodeReviewResponse> CodeReviewResponseList = null;

        static formCodeReviewStats()
        {
            TeamProjectCollectionUrl = ConfigurationManager.AppSettings["TeamProjectCollectionUrl"].ToString();
        }

        public formCodeReviewStats()
        {
            InitializeComponent();
        }

        private void btnFetchResults_Click(object sender, EventArgs e)
        {
            var filter = new CodeReviewResponseFilter
            {
                StartDate = datePickerStartDate.Value,
                EndDate = datePickerEndDate.Value,
                Reviewer = txtReviewer.Text
            };

            CodeReviewResponseList = CodeReviewStatsHelper.RetrieveCodeReviewResponsesByFilter(filter);
            grdCodeReviewStats.DataSource = CodeReviewResponseList.ToList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReviewer.Text = string.Empty;
            CodeReviewResponseList = null;
            grdCodeReviewStats.DataSource = null;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (null != CodeReviewResponseList)
            {
                string FileName = ConfigurationManager.AppSettings["ExcelFilePath"].ToString();

                ExcelHelper.GenerateExcelDocument(FileName, CodeReviewResponseList);
            }
        }
    }
}
