namespace CodeReviewStats
{
    partial class formCodeReviewStats
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.datePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.datePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblReviewer = new System.Windows.Forms.Label();
            this.txtReviewer = new System.Windows.Forms.TextBox();
            this.btnFetchResults = new System.Windows.Forms.Button();
            this.grdCodeReviewStats = new System.Windows.Forms.DataGridView();
            this.CodeReviewCommentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closedStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeReviewRequestIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeReviewResponseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExportToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCodeReviewStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeReviewResponseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(24, 28);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date";
            // 
            // datePickerStartDate
            // 
            this.datePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerStartDate.Location = new System.Drawing.Point(85, 23);
            this.datePickerStartDate.Name = "datePickerStartDate";
            this.datePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.datePickerStartDate.TabIndex = 1;
            // 
            // datePickerEndDate
            // 
            this.datePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerEndDate.Location = new System.Drawing.Point(426, 23);
            this.datePickerEndDate.Name = "datePickerEndDate";
            this.datePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.datePickerEndDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(365, 28);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "End Date";
            // 
            // lblReviewer
            // 
            this.lblReviewer.AutoSize = true;
            this.lblReviewer.Location = new System.Drawing.Point(27, 67);
            this.lblReviewer.Name = "lblReviewer";
            this.lblReviewer.Size = new System.Drawing.Size(52, 13);
            this.lblReviewer.TabIndex = 4;
            this.lblReviewer.Text = "Reviewer";
            // 
            // txtReviewer
            // 
            this.txtReviewer.Location = new System.Drawing.Point(85, 62);
            this.txtReviewer.Name = "txtReviewer";
            this.txtReviewer.Size = new System.Drawing.Size(200, 20);
            this.txtReviewer.TabIndex = 5;
            // 
            // btnFetchResults
            // 
            this.btnFetchResults.Location = new System.Drawing.Point(368, 62);
            this.btnFetchResults.Name = "btnFetchResults";
            this.btnFetchResults.Size = new System.Drawing.Size(107, 23);
            this.btnFetchResults.TabIndex = 6;
            this.btnFetchResults.Text = "Fetch Results";
            this.btnFetchResults.UseVisualStyleBackColor = true;
            this.btnFetchResults.Click += new System.EventHandler(this.btnFetchResults_Click);
            // 
            // grdCodeReviewStats
            // 
            this.grdCodeReviewStats.AllowUserToAddRows = false;
            this.grdCodeReviewStats.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCodeReviewStats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCodeReviewStats.AutoGenerateColumns = false;
            this.grdCodeReviewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCodeReviewStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.reviewedByDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.closedDateDataGridViewTextBoxColumn,
            this.closedStatusDataGridViewTextBoxColumn,
            this.codeReviewRequestIdDataGridViewTextBoxColumn,
            this.CodeReviewCommentCount});
            this.grdCodeReviewStats.DataSource = this.codeReviewResponseBindingSource;
            this.grdCodeReviewStats.Location = new System.Drawing.Point(30, 147);
            this.grdCodeReviewStats.Name = "grdCodeReviewStats";
            this.grdCodeReviewStats.ReadOnly = true;
            this.grdCodeReviewStats.Size = new System.Drawing.Size(596, 260);
            this.grdCodeReviewStats.TabIndex = 7;
            // 
            // CodeReviewCommentCount
            // 
            this.CodeReviewCommentCount.DataPropertyName = "CodeReviewCommentCount";
            this.CodeReviewCommentCount.HeaderText = "CodeReviewCommentCount";
            this.CodeReviewCommentCount.Name = "CodeReviewCommentCount";
            this.CodeReviewCommentCount.ReadOnly = true;
            this.CodeReviewCommentCount.Width = 163;
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(513, 62);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 39;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdByDataGridViewTextBoxColumn.Width = 79;
            // 
            // reviewedByDataGridViewTextBoxColumn
            // 
            this.reviewedByDataGridViewTextBoxColumn.DataPropertyName = "ReviewedBy";
            this.reviewedByDataGridViewTextBoxColumn.HeaderText = "ReviewedBy";
            this.reviewedByDataGridViewTextBoxColumn.Name = "reviewedByDataGridViewTextBoxColumn";
            this.reviewedByDataGridViewTextBoxColumn.ReadOnly = true;
            this.reviewedByDataGridViewTextBoxColumn.Width = 90;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 50;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdDateDataGridViewTextBoxColumn.Width = 90;
            // 
            // closedDateDataGridViewTextBoxColumn
            // 
            this.closedDateDataGridViewTextBoxColumn.DataPropertyName = "ClosedDate";
            this.closedDateDataGridViewTextBoxColumn.HeaderText = "ClosedDate";
            this.closedDateDataGridViewTextBoxColumn.Name = "closedDateDataGridViewTextBoxColumn";
            this.closedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.closedDateDataGridViewTextBoxColumn.Width = 85;
            // 
            // closedStatusDataGridViewTextBoxColumn
            // 
            this.closedStatusDataGridViewTextBoxColumn.DataPropertyName = "ClosedStatus";
            this.closedStatusDataGridViewTextBoxColumn.HeaderText = "ClosedStatus";
            this.closedStatusDataGridViewTextBoxColumn.Name = "closedStatusDataGridViewTextBoxColumn";
            this.closedStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.closedStatusDataGridViewTextBoxColumn.Width = 92;
            // 
            // codeReviewRequestIdDataGridViewTextBoxColumn
            // 
            this.codeReviewRequestIdDataGridViewTextBoxColumn.DataPropertyName = "CodeReviewRequestId";
            this.codeReviewRequestIdDataGridViewTextBoxColumn.HeaderText = "CodeReviewRequestId";
            this.codeReviewRequestIdDataGridViewTextBoxColumn.Name = "codeReviewRequestIdDataGridViewTextBoxColumn";
            this.codeReviewRequestIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeReviewRequestIdDataGridViewTextBoxColumn.Width = 140;
            // 
            // codeReviewResponseBindingSource
            // 
            this.codeReviewResponseBindingSource.DataSource = typeof(CodeReviewStats.CodeReviewResponse);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(368, 105);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(107, 23);
            this.btnExportToExcel.TabIndex = 9;
            this.btnExportToExcel.Text = "Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // formCodeReviewStats
            // 
            this.AcceptButton = this.btnFetchResults;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(686, 441);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grdCodeReviewStats);
            this.Controls.Add(this.btnFetchResults);
            this.Controls.Add(this.txtReviewer);
            this.Controls.Add(this.lblReviewer);
            this.Controls.Add(this.datePickerEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.datePickerStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Name = "formCodeReviewStats";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Review Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.grdCodeReviewStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeReviewResponseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker datePickerStartDate;
        private System.Windows.Forms.DateTimePicker datePickerEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblReviewer;
        private System.Windows.Forms.TextBox txtReviewer;
        private System.Windows.Forms.Button btnFetchResults;
        private System.Windows.Forms.DataGridView grdCodeReviewStats;
        private System.Windows.Forms.BindingSource codeReviewResponseBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closedStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeReviewRequestIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeReviewCommentCount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExportToExcel;
    }
}

