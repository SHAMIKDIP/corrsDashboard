using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Configurationmaster
    {
        public int Id { get; set; }
        public string InputRoot { get; set; }
        public string InputFolderPath { get; set; }
        public string StageRoot { get; set; }
        public string StageFolderPath { get; set; }
        public string InputFileName { get; set; }
        public string SftphostName { get; set; }
        public string SftpuserName { get; set; }
        public string SftpfilePath { get; set; }
        public string SheetName { get; set; }
        public string SftpfileName { get; set; }
        public string StageFileName { get; set; }
        public string DuplicateRoot { get; set; }
        public string DuplicateFolderPath { get; set; }
        public string DuplicateFileName { get; set; }
        public string ProcessedRoot { get; set; }
        public string ProcessedFolderPath { get; set; }
        public string ProcessedFileName { get; set; }
        public string DeletedRoot { get; set; }
        public string DeletedFolderPath { get; set; }
        public string DeletedFileName { get; set; }
        public string SuccessRoot { get; set; }
        public string SuccessFolderPath { get; set; }
        public string SuccessFileName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? MetricId { get; set; }
        public string MetricTableName { get; set; }
        public string DbFileName { get; set; }
        public string LogRoot { get; set; }
        public string LogFolderPath { get; set; }

        public virtual Corrsmetrics Metric { get; set; }
    }
}
