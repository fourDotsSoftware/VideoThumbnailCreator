namespace VideoThumbnailCreator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmsVideos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timJoinVideos = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblTotalVideos = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblTotalDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCut = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbAddFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbJoinVideos = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importVideosFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importVideosFromCSVFIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importVideosFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterListOfVideosToJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveJoinArgsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.useFFMPEG64bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useFFMPEG32bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyEXIFInformationFromSelectedVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepCreationDateFromSelectedVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepLastModificationDateFromSelectedVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiToolsPlayOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.joinVideosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractThumbnailImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tiToolsPlayOutputCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.tiToolsOpenOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tiToolsExploreOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tiToolsCopyPathOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tiToolsVideoInfoOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFreeApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnGooglePlusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnLinkedinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareWithEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpUsersManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebpageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgVideo = new System.Windows.Forms.DataGridView();
            this.colVideo = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmsVideos.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tsCut.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmsVideos
            // 
            this.cmsVideos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.copyFullPathToolStripMenuItem,
            this.videoInfoToolStripMenuItem});
            this.cmsVideos.Name = "cmsVideos";
            resources.ApplyResources(this.cmsVideos, "cmsVideos");
            this.cmsVideos.Opening += new System.ComponentModel.CancelEventHandler(this.cmsVideos_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.flash;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.folder;
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // copyFullPathToolStripMenuItem
            // 
            this.copyFullPathToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.copy;
            this.copyFullPathToolStripMenuItem.Name = "copyFullPathToolStripMenuItem";
            resources.ApplyResources(this.copyFullPathToolStripMenuItem, "copyFullPathToolStripMenuItem");
            this.copyFullPathToolStripMenuItem.Click += new System.EventHandler(this.copyFullPathToolStripMenuItem_Click);
            // 
            // videoInfoToolStripMenuItem
            // 
            this.videoInfoToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.information;
            this.videoInfoToolStripMenuItem.Name = "videoInfoToolStripMenuItem";
            resources.ApplyResources(this.videoInfoToolStripMenuItem, "videoInfoToolStripMenuItem");
            this.videoInfoToolStripMenuItem.Click += new System.EventHandler(this.videoInfoToolStripMenuItem_Click);
            // 
            // timJoinVideos
            // 
            this.timJoinVideos.Interval = 1000;
            this.timJoinVideos.Tick += new System.EventHandler(this.timJoinVideos_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.slblTotalVideos,
            this.slblTotalDuration,
            this.lblElapsedTime});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Spring = true;
            // 
            // slblTotalVideos
            // 
            this.slblTotalVideos.ForeColor = System.Drawing.Color.DimGray;
            this.slblTotalVideos.Name = "slblTotalVideos";
            resources.ApplyResources(this.slblTotalVideos, "slblTotalVideos");
            // 
            // slblTotalDuration
            // 
            this.slblTotalDuration.ForeColor = System.Drawing.Color.DimGray;
            this.slblTotalDuration.Name = "slblTotalDuration";
            resources.ApplyResources(this.slblTotalDuration, "slblTotalDuration");
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Name = "lblElapsedTime";
            resources.ApplyResources(this.lblElapsedTime, "lblElapsedTime");
            // 
            // tsCut
            // 
            resources.ApplyResources(this.tsCut, "tsCut");
            this.tsCut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbAddFolder,
            this.tsbRemove,
            this.toolStripSeparator6,
            this.tsbJoinVideos});
            this.tsCut.Name = "tsCut";
            // 
            // tsbAdd
            // 
            resources.ApplyResources(this.tsbAdd, "tsbAdd");
            this.tsbAdd.Image = global::VideoThumbnailCreator.Properties.Resources.add1;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.ButtonClick += new System.EventHandler(this.tsbAdd_ButtonClick);
            this.tsbAdd.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbAdd_DropDownItemClicked);
            // 
            // tsbAddFolder
            // 
            resources.ApplyResources(this.tsbAddFolder, "tsbAddFolder");
            this.tsbAddFolder.Image = global::VideoThumbnailCreator.Properties.Resources.folder_add;
            this.tsbAddFolder.Name = "tsbAddFolder";
            this.tsbAddFolder.ButtonClick += new System.EventHandler(this.tsbAddFolder_ButtonClick);
            this.tsbAddFolder.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbAddFolder_DropDownItemClicked);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::VideoThumbnailCreator.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tsbJoinVideos
            // 
            resources.ApplyResources(this.tsbJoinVideos, "tsbJoinVideos");
            this.tsbJoinVideos.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbJoinVideos.Image = global::VideoThumbnailCreator.Properties.Resources.flash1;
            this.tsbJoinVideos.Name = "tsbJoinVideos";
            this.tsbJoinVideos.Click += new System.EventHandler(this.tsbJoinVideos_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.tiToolsPlayOutput,
            this.languageToolStripMenuItem,
            this.downloadFreeApplicationsToolStripMenuItem,
            this.pleaseShareToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.importVideosFromTextFileToolStripMenuItem,
            this.importVideosFromCSVFIleToolStripMenuItem,
            this.importVideosFromExcelFileToolStripMenuItem,
            this.enterListOfVideosToJoinToolStripMenuItem,
            this.saveCurrentSelectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem,
            this.saveJoinArgsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.add;
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            resources.ApplyResources(this.addFileToolStripMenuItem, "addFileToolStripMenuItem");
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.tsbAdd_ButtonClick);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.tsbAddFolder_ButtonClick);
            // 
            // importVideosFromTextFileToolStripMenuItem
            // 
            this.importVideosFromTextFileToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.import1;
            this.importVideosFromTextFileToolStripMenuItem.Name = "importVideosFromTextFileToolStripMenuItem";
            resources.ApplyResources(this.importVideosFromTextFileToolStripMenuItem, "importVideosFromTextFileToolStripMenuItem");
            this.importVideosFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.importVideosFromTextFileToolStripMenuItem_Click);
            // 
            // importVideosFromCSVFIleToolStripMenuItem
            // 
            this.importVideosFromCSVFIleToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.import1;
            this.importVideosFromCSVFIleToolStripMenuItem.Name = "importVideosFromCSVFIleToolStripMenuItem";
            resources.ApplyResources(this.importVideosFromCSVFIleToolStripMenuItem, "importVideosFromCSVFIleToolStripMenuItem");
            this.importVideosFromCSVFIleToolStripMenuItem.Click += new System.EventHandler(this.importVideosFromCSVFIleToolStripMenuItem_Click);
            // 
            // importVideosFromExcelFileToolStripMenuItem
            // 
            this.importVideosFromExcelFileToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.import1;
            this.importVideosFromExcelFileToolStripMenuItem.Name = "importVideosFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importVideosFromExcelFileToolStripMenuItem, "importVideosFromExcelFileToolStripMenuItem");
            this.importVideosFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importVideosFromExcelFileToolStripMenuItem_Click);
            // 
            // enterListOfVideosToJoinToolStripMenuItem
            // 
            this.enterListOfVideosToJoinToolStripMenuItem.Name = "enterListOfVideosToJoinToolStripMenuItem";
            resources.ApplyResources(this.enterListOfVideosToJoinToolStripMenuItem, "enterListOfVideosToJoinToolStripMenuItem");
            this.enterListOfVideosToJoinToolStripMenuItem.Click += new System.EventHandler(this.enterListOfVideosToJoinToolStripMenuItem_Click);
            // 
            // saveCurrentSelectionToolStripMenuItem
            // 
            this.saveCurrentSelectionToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.disk_blue;
            this.saveCurrentSelectionToolStripMenuItem.Name = "saveCurrentSelectionToolStripMenuItem";
            resources.ApplyResources(this.saveCurrentSelectionToolStripMenuItem, "saveCurrentSelectionToolStripMenuItem");
            this.saveCurrentSelectionToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentSelectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveJoinArgsToolStripMenuItem
            // 
            this.saveJoinArgsToolStripMenuItem.Name = "saveJoinArgsToolStripMenuItem";
            resources.ApplyResources(this.saveJoinArgsToolStripMenuItem, "saveJoinArgsToolStripMenuItem");
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            resources.ApplyResources(this.unselectAllToolStripMenuItem, "unselectAllToolStripMenuItem");
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.useFFMPEG64bitToolStripMenuItem,
            this.useFFMPEG32bitToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyEXIFInformationFromSelectedVideoToolStripMenuItem,
            this.keepCreationDateFromSelectedVideoToolStripMenuItem,
            this.keepLastModificationDateFromSelectedVideoToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            resources.ApplyResources(this.optionsToolStripMenuItem1, "optionsToolStripMenuItem1");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.preferences;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // useFFMPEG64bitToolStripMenuItem
            // 
            this.useFFMPEG64bitToolStripMenuItem.Name = "useFFMPEG64bitToolStripMenuItem";
            resources.ApplyResources(this.useFFMPEG64bitToolStripMenuItem, "useFFMPEG64bitToolStripMenuItem");
            this.useFFMPEG64bitToolStripMenuItem.Click += new System.EventHandler(this.useFFMPEG64bitToolStripMenuItem_Click);
            // 
            // useFFMPEG32bitToolStripMenuItem
            // 
            this.useFFMPEG32bitToolStripMenuItem.Name = "useFFMPEG32bitToolStripMenuItem";
            resources.ApplyResources(this.useFFMPEG32bitToolStripMenuItem, "useFFMPEG32bitToolStripMenuItem");
            this.useFFMPEG32bitToolStripMenuItem.Click += new System.EventHandler(this.useFFMPEG32bitToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // copyEXIFInformationFromSelectedVideoToolStripMenuItem
            // 
            this.copyEXIFInformationFromSelectedVideoToolStripMenuItem.CheckOnClick = true;
            this.copyEXIFInformationFromSelectedVideoToolStripMenuItem.Name = "copyEXIFInformationFromSelectedVideoToolStripMenuItem";
            resources.ApplyResources(this.copyEXIFInformationFromSelectedVideoToolStripMenuItem, "copyEXIFInformationFromSelectedVideoToolStripMenuItem");
            this.copyEXIFInformationFromSelectedVideoToolStripMenuItem.Click += new System.EventHandler(this.copyEXIFInformationFromSelectedVideoToolStripMenuItem_Click);
            // 
            // keepCreationDateFromSelectedVideoToolStripMenuItem
            // 
            this.keepCreationDateFromSelectedVideoToolStripMenuItem.CheckOnClick = true;
            this.keepCreationDateFromSelectedVideoToolStripMenuItem.Name = "keepCreationDateFromSelectedVideoToolStripMenuItem";
            resources.ApplyResources(this.keepCreationDateFromSelectedVideoToolStripMenuItem, "keepCreationDateFromSelectedVideoToolStripMenuItem");
            this.keepCreationDateFromSelectedVideoToolStripMenuItem.Click += new System.EventHandler(this.keepCreationDateFromSelectedVideoToolStripMenuItem_Click);
            // 
            // keepLastModificationDateFromSelectedVideoToolStripMenuItem
            // 
            this.keepLastModificationDateFromSelectedVideoToolStripMenuItem.CheckOnClick = true;
            this.keepLastModificationDateFromSelectedVideoToolStripMenuItem.Name = "keepLastModificationDateFromSelectedVideoToolStripMenuItem";
            resources.ApplyResources(this.keepLastModificationDateFromSelectedVideoToolStripMenuItem, "keepLastModificationDateFromSelectedVideoToolStripMenuItem");
            this.keepLastModificationDateFromSelectedVideoToolStripMenuItem.Click += new System.EventHandler(this.keepLastModificationDateFromSelectedVideoToolStripMenuItem_Click);
            // 
            // tiToolsPlayOutput
            // 
            this.tiToolsPlayOutput.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinVideosToolStripMenuItem,
            this.extractThumbnailImagesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.tiToolsPlayOutputCommand,
            this.tiToolsOpenOutput,
            this.tiToolsExploreOutput,
            this.tiToolsCopyPathOutput,
            this.tiToolsVideoInfoOutput});
            this.tiToolsPlayOutput.Name = "tiToolsPlayOutput";
            resources.ApplyResources(this.tiToolsPlayOutput, "tiToolsPlayOutput");
            // 
            // joinVideosToolStripMenuItem
            // 
            this.joinVideosToolStripMenuItem.Name = "joinVideosToolStripMenuItem";
            resources.ApplyResources(this.joinVideosToolStripMenuItem, "joinVideosToolStripMenuItem");
            this.joinVideosToolStripMenuItem.Click += new System.EventHandler(this.tsbJoinVideos_Click);
            // 
            // extractThumbnailImagesToolStripMenuItem
            // 
            this.extractThumbnailImagesToolStripMenuItem.Name = "extractThumbnailImagesToolStripMenuItem";
            resources.ApplyResources(this.extractThumbnailImagesToolStripMenuItem, "extractThumbnailImagesToolStripMenuItem");
            this.extractThumbnailImagesToolStripMenuItem.Click += new System.EventHandler(this.extractThumbnailImagesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // tiToolsPlayOutputCommand
            // 
            resources.ApplyResources(this.tiToolsPlayOutputCommand, "tiToolsPlayOutputCommand");
            this.tiToolsPlayOutputCommand.Name = "tiToolsPlayOutputCommand";
            // 
            // tiToolsOpenOutput
            // 
            resources.ApplyResources(this.tiToolsOpenOutput, "tiToolsOpenOutput");
            this.tiToolsOpenOutput.Image = global::VideoThumbnailCreator.Properties.Resources.flash;
            this.tiToolsOpenOutput.Name = "tiToolsOpenOutput";
            this.tiToolsOpenOutput.Click += new System.EventHandler(this.tiToolsOpenOutput_Click);
            // 
            // tiToolsExploreOutput
            // 
            resources.ApplyResources(this.tiToolsExploreOutput, "tiToolsExploreOutput");
            this.tiToolsExploreOutput.Image = global::VideoThumbnailCreator.Properties.Resources.folder;
            this.tiToolsExploreOutput.Name = "tiToolsExploreOutput";
            this.tiToolsExploreOutput.Click += new System.EventHandler(this.tiToolsExploreOutput_Click);
            // 
            // tiToolsCopyPathOutput
            // 
            resources.ApplyResources(this.tiToolsCopyPathOutput, "tiToolsCopyPathOutput");
            this.tiToolsCopyPathOutput.Image = global::VideoThumbnailCreator.Properties.Resources.copy;
            this.tiToolsCopyPathOutput.Name = "tiToolsCopyPathOutput";
            this.tiToolsCopyPathOutput.Click += new System.EventHandler(this.tiToolsCopyPathOutput_Click);
            // 
            // tiToolsVideoInfoOutput
            // 
            resources.ApplyResources(this.tiToolsVideoInfoOutput, "tiToolsVideoInfoOutput");
            this.tiToolsVideoInfoOutput.Image = global::VideoThumbnailCreator.Properties.Resources.information;
            this.tiToolsVideoInfoOutput.Name = "tiToolsVideoInfoOutput";
            this.tiToolsVideoInfoOutput.Click += new System.EventHandler(this.tiToolsVideoInfoOutput_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languages1ToolStripMenuItem,
            this.languages2ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // languages1ToolStripMenuItem
            // 
            this.languages1ToolStripMenuItem.Name = "languages1ToolStripMenuItem";
            resources.ApplyResources(this.languages1ToolStripMenuItem, "languages1ToolStripMenuItem");
            // 
            // languages2ToolStripMenuItem
            // 
            this.languages2ToolStripMenuItem.Name = "languages2ToolStripMenuItem";
            resources.ApplyResources(this.languages2ToolStripMenuItem, "languages2ToolStripMenuItem");
            // 
            // downloadFreeApplicationsToolStripMenuItem
            // 
            this.downloadFreeApplicationsToolStripMenuItem.Name = "downloadFreeApplicationsToolStripMenuItem";
            resources.ApplyResources(this.downloadFreeApplicationsToolStripMenuItem, "downloadFreeApplicationsToolStripMenuItem");
            // 
            // pleaseShareToolStripMenuItem
            // 
            this.pleaseShareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareOnFacebookToolStripMenuItem,
            this.shareOnTwitterToolStripMenuItem,
            this.shareOnGooglePlusToolStripMenuItem,
            this.shareOnLinkedinToolStripMenuItem,
            this.shareWithEmailToolStripMenuItem});
            this.pleaseShareToolStripMenuItem.Name = "pleaseShareToolStripMenuItem";
            resources.ApplyResources(this.pleaseShareToolStripMenuItem, "pleaseShareToolStripMenuItem");
            // 
            // shareOnFacebookToolStripMenuItem
            // 
            this.shareOnFacebookToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.facebook_24;
            this.shareOnFacebookToolStripMenuItem.Name = "shareOnFacebookToolStripMenuItem";
            resources.ApplyResources(this.shareOnFacebookToolStripMenuItem, "shareOnFacebookToolStripMenuItem");
            this.shareOnFacebookToolStripMenuItem.Click += new System.EventHandler(this.shareOnFacebookToolStripMenuItem_Click);
            // 
            // shareOnTwitterToolStripMenuItem
            // 
            this.shareOnTwitterToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.twitter_24;
            this.shareOnTwitterToolStripMenuItem.Name = "shareOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.shareOnTwitterToolStripMenuItem, "shareOnTwitterToolStripMenuItem");
            this.shareOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.shareOnTwitterToolStripMenuItem_Click);
            // 
            // shareOnGooglePlusToolStripMenuItem
            // 
            this.shareOnGooglePlusToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.googleplus_24;
            this.shareOnGooglePlusToolStripMenuItem.Name = "shareOnGooglePlusToolStripMenuItem";
            resources.ApplyResources(this.shareOnGooglePlusToolStripMenuItem, "shareOnGooglePlusToolStripMenuItem");
            this.shareOnGooglePlusToolStripMenuItem.Click += new System.EventHandler(this.shareOnGooglePlusToolStripMenuItem_Click);
            // 
            // shareOnLinkedinToolStripMenuItem
            // 
            this.shareOnLinkedinToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.linkedin_24;
            this.shareOnLinkedinToolStripMenuItem.Name = "shareOnLinkedinToolStripMenuItem";
            resources.ApplyResources(this.shareOnLinkedinToolStripMenuItem, "shareOnLinkedinToolStripMenuItem");
            this.shareOnLinkedinToolStripMenuItem.Click += new System.EventHandler(this.shareOnLinkedinToolStripMenuItem_Click);
            // 
            // shareWithEmailToolStripMenuItem
            // 
            this.shareWithEmailToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.mail;
            this.shareWithEmailToolStripMenuItem.Name = "shareWithEmailToolStripMenuItem";
            resources.ApplyResources(this.shareWithEmailToolStripMenuItem, "shareWithEmailToolStripMenuItem");
            this.shareWithEmailToolStripMenuItem.Click += new System.EventHandler(this.shareWithEmailToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpUsersManualToolStripMenuItem,
            this.toolStripMenuItem4,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebpageToolStripMenuItem,
            this.toolStripMenuItem9,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.feedbackToolStripMenuItem,
            this.checkForNewVersionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpUsersManualToolStripMenuItem
            // 
            this.helpUsersManualToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.help2;
            this.helpUsersManualToolStripMenuItem.Name = "helpUsersManualToolStripMenuItem";
            resources.ApplyResources(this.helpUsersManualToolStripMenuItem, "helpUsersManualToolStripMenuItem");
            this.helpUsersManualToolStripMenuItem.Click += new System.EventHandler(this.helpUsersManualToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebpageToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.earth;
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Name = "visit4dotsSoftwareWebpageToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebpageToolStripMenuItem, "visit4dotsSoftwareWebpageToolStripMenuItem");
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebpageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Image = global::VideoThumbnailCreator.Properties.Resources.edit;
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            resources.ApplyResources(this.feedbackToolStripMenuItem, "feedbackToolStripMenuItem");
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionToolStripMenuItem, "checkForNewVersionToolStripMenuItem");
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dgVideo
            // 
            this.dgVideo.AllowDrop = true;
            this.dgVideo.AllowUserToAddRows = false;
            this.dgVideo.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgVideo, "dgVideo");
            this.dgVideo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgVideo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgVideo.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVideo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVideo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVideo});
            this.dgVideo.ContextMenuStrip = this.cmsVideos;
            this.dgVideo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgVideo.Name = "dgVideo";
            this.dgVideo.RowHeadersVisible = false;
            this.dgVideo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVideo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVideo_CellContentClick);
            this.dgVideo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVideo_CellFormatting);
            this.dgVideo.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgVideo_CellMouseMove);
            this.dgVideo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgVideo_CellPainting);
            this.dgVideo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgVideo_EditingControlShowing);
            this.dgVideo.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragDrop);
            this.dgVideo.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragEnter);
            this.dgVideo.DragOver += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragOver);
            // 
            // colVideo
            // 
            this.colVideo.DataPropertyName = "videoimg";
            resources.ApplyResources(this.colVideo, "colVideo");
            this.colVideo.Name = "colVideo";
            this.colVideo.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ind";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "videoimg";
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsCut);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgVideo);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVideoJoin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVideoJoin_FormClosed);
            this.Load += new System.EventHandler(this.frmVideoJoin_Load);
            this.cmsVideos.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsCut.ResumeLayout(false);
            this.tsCut.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsCut;
        public System.Windows.Forms.ToolStripSplitButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbJoinVideos;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel slblTotalVideos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripStatusLabel slblTotalDuration;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timJoinVideos;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsedTime;
        private System.Windows.Forms.ContextMenuStrip cmsVideos;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFullPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoInfoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpUsersManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebpageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pleaseShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnGooglePlusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnLinkedinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareWithEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadFreeApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languages1ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languages2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiToolsPlayOutput;
        public System.Windows.Forms.DataGridView dgVideo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem importVideosFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importVideosFromCSVFIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importVideosFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enterListOfVideosToJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        public System.Windows.Forms.ToolStripSplitButton tsbAddFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tiToolsPlayOutputCommand;
        private System.Windows.Forms.ToolStripMenuItem tiToolsOpenOutput;
        private System.Windows.Forms.ToolStripMenuItem tiToolsExploreOutput;
        private System.Windows.Forms.ToolStripMenuItem tiToolsCopyPathOutput;
        private System.Windows.Forms.ToolStripMenuItem tiToolsVideoInfoOutput;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentSelectionToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveJoinArgsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinVideosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem copyEXIFInformationFromSelectedVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepCreationDateFromSelectedVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepLastModificationDateFromSelectedVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useFFMPEG64bitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useFFMPEG32bitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewImageColumn colVideo;
        private System.Windows.Forms.ToolStripMenuItem extractThumbnailImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
    }
}
