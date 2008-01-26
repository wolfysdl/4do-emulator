#include "MainFrame.h"
#include "CodeViewer.h"

/////////////////////////////////////////////////////////////////////////
// Menu items.
/////////////////////////////////////////////////////////////////////////
enum Menu
{
   ID_MENU_FILE_OPENISO = 1,
   ID_MENU_FILE_EXIT,
   ID_MENU_TOOLS_BROWSEISO,
   ID_MENU_TOOLS_VIEWCODE,
   ID_MENU_HELP_ABOUT
};

BEGIN_EVENT_TABLE(MainFrame, wxFrame)
   EVT_MENU(ID_MENU_FILE_OPENISO, MainFrame::OnMenuFileOpenISO)
   EVT_MENU(ID_MENU_FILE_EXIT, MainFrame::OnMenuFileExit)
   EVT_MENU(ID_MENU_TOOLS_BROWSEISO, MainFrame::OnMenuToolsBrowseISO)
   EVT_MENU(ID_MENU_TOOLS_VIEWCODE, MainFrame::OnMenuToolsViewCode)
   EVT_MENU(ID_MENU_HELP_ABOUT, MainFrame::OnMenuHelpAbout)
END_EVENT_TABLE()

/////////////////////////////////////////////////////////////////////////
// Frame startup
/////////////////////////////////////////////////////////////////////////

MainFrame::MainFrame(wxCmdLineParser* parser)
      : wxFrame((wxFrame *) NULL, -1, wxEmptyString, wxDefaultPosition, wxDefaultSize)
{
   /////////////////////
   // Handle command-line arguments.
   m_isDebug = parser->Found ("d");
   if (parser->Found ("li"))
   {
      parser->Found ("li", &m_fileName);
   }
   
   /////////////////////
   // GUI Setup.
   this->SetTitle ("4DO");
   this->SetIcon (wxIcon(fourdo_xpm));
	this->SetSize (1000, 800);
	this->CenterOnScreen ();
	
	//this->SetBackgroundStyle (wxBackgroundStyle::wxBG_STYLE_SYSTEM);
	//this->SetBackgroundColour (wxSystemColour::wxSYS_COLOUR_3DFACE);
	this->SetBackgroundColour (wxColor (0xFFFFFFFF));
	this->CreateStatusBar ();
	this->SetStatusText (_T("4DO: Open-Source HLE 3DO Emulator"));
   this->InitializeMenu ();	
	
   // Set up a sizer with empty panel and a debug output area.
   wxFlexGridSizer *sizerMain = new wxFlexGridSizer (1, 2, 0, 0);
   this->SetSizer (sizerMain);
   sizerMain->AddGrowableCol (0, 3);
   sizerMain->AddGrowableCol (1, 3);
   sizerMain->AddGrowableRow (0, 0);
   sizerMain->SetFlexibleDirection (wxBOTH);
	
	// A quick debug grid
	grdDebug = new wxGrid (this, wxID_ANY);
   sizerMain->Add (grdDebug, 0, wxEXPAND, 0);

   // CPU Status panel
	wxStaticBox *fraCPUStatus = new wxStaticBox(this, wxID_ANY, _T("&CPU Status"));
   wxSizer *sizerStatus = new wxStaticBoxSizer(fraCPUStatus, wxBOTH);
   sizerMain->Add (sizerStatus, 0, wxEXPAND, 0);
   fraCPUStatus->SetBackgroundColour (wxColor (0xFFFFFFFF));
   
   grdCPUStatus = new wxGrid (this, wxID_ANY);
   grdCPUStatus->CreateGrid (1, 4, wxGrid::wxGridSelectCells);
   grdCPUStatus->SetRowLabelSize (0);
   grdCPUStatus->SetColLabelSize (20);
   
   sizerStatus->Add (grdCPUStatus, 0, wxALL | wxGROW, 5);
	
   ///////////////   
   if (m_isDebug)
   {
      // Do our test here.
      this->DoTest ();
   }
}

MainFrame::~MainFrame()
{
}

void MainFrame::DoTest ()
{
   #define ROM_LOAD_ADDRESS 0x00100000
   #define INSTRUCTIONS     8

   wxString  bits;
   Console*  con;
   bool      success;
   uint      fileSize;
   
   con = new Console ();
   
   /////////////////
   // Open Launchme!
	uint32_t  bytesRead;
	
	File f(m_fileName);

	success = f.openFile("/launchme");
	if (!success)
	{
		// Error opening
		delete con;
		return;
	}
   
   /////////////////
   // Load it into memory.
   fileSize = f.getFileSize ();
   f.read (con->DMA ()->GetDRAMPointer (ROM_LOAD_ADDRESS), f.getFileSize (), &bytesRead);
   
   /////////////////
   // Setup grid.
   grdDebug->CreateGrid (0, 3, wxGrid::wxGridSelectCells);
   grdDebug->EnableDragRowSize (false);
   grdDebug->EnableEditing (false);
   grdDebug->SetColLabelValue (0, "Cnd");
   grdDebug->SetColLabelValue (1, "Instruction");
   grdDebug->SetColLabelValue (2, "Last CPU Result");
   
   // Setup Status Grid
   grdCPUStatus->EnableDragRowSize (false);
   grdCPUStatus->EnableEditing (false);
   
   grdCPUStatus->SetColLabelValue (0, "Reg");
   grdCPUStatus->SetColLabelValue (1, "Val");
   grdCPUStatus->SetColLabelValue (2, "Val (Bin)");
   grdCPUStatus->SetColLabelValue (3, "Val (Hex)");
   
   *(con->CPU ()->REG->PC ()->Value) = ROM_LOAD_ADDRESS;
   
   for (uint row = 0; row < INSTRUCTIONS; row++)
   {
      // Read an instruction.
      uint token;
      uint PCBefore;
      uint PCAfter;
      
      PCBefore = *(con->CPU ()->REG->PC ()->Value);
      token = con->DMA ()->GetValue (PCBefore);

      // Convert this thing to bits.
      bits = UintToBitString (token);

      // Process it.
      PCBefore = *(con->CPU ()->REG->PC ()->Value);
      con->CPU ()->DoSingleInstruction ();
      PCAfter = *(con->CPU ()->REG->PC ()->Value);

      // Increment PC if no change was made.
      if (PCBefore == PCAfter)
         *(con->CPU ()->REG->PC ()->Value) += 4;

      // Update CPU Status
      grdCPUStatus->DeleteRows (0, grdCPUStatus->GetRows ());
      grdCPUStatus->InsertRows (0, 37);

      int regNum = 0;
      this->UpdateGridRow (con, regNum++, "R00", IR_R00);
      this->UpdateGridRow (con, regNum++, "R01", IR_R01);
      this->UpdateGridRow (con, regNum++, "R02", IR_R02);
      this->UpdateGridRow (con, regNum++, "R03", IR_R03);
      this->UpdateGridRow (con, regNum++, "R04", IR_R04);
      this->UpdateGridRow (con, regNum++, "R05", IR_R05);
      this->UpdateGridRow (con, regNum++, "R06", IR_R06);
      this->UpdateGridRow (con, regNum++, "R07", IR_R07);
      this->UpdateGridRow (con, regNum++, "R08", IR_R08);
      this->UpdateGridRow (con, regNum++, "R09", IR_R09);
      this->UpdateGridRow (con, regNum++, "R10", IR_R10);
      this->UpdateGridRow (con, regNum++, "R11", IR_R11);
      this->UpdateGridRow (con, regNum++, "R12", IR_R12);
      this->UpdateGridRow (con, regNum++, "R13", IR_R13);
      this->UpdateGridRow (con, regNum++, "R14", IR_R14);
      this->UpdateGridRow (con, regNum++, "PC", IR_PC);
      this->UpdateGridRow (con, regNum++, "R08_FIQ", IR_R08_FIQ);
      this->UpdateGridRow (con, regNum++, "R09_FIQ", IR_R09_FIQ);
      this->UpdateGridRow (con, regNum++, "R10_FIQ", IR_R10_FIQ);
      this->UpdateGridRow (con, regNum++, "R11_FIQ", IR_R11_FIQ);
      this->UpdateGridRow (con, regNum++, "R12_FIQ", IR_R12_FIQ);
      this->UpdateGridRow (con, regNum++, "R13_FIQ", IR_R13_FIQ);
      this->UpdateGridRow (con, regNum++, "R14_FIQ", IR_R14_FIQ);
      this->UpdateGridRow (con, regNum++, "R13_SVC", IR_R13_SVC);
      this->UpdateGridRow (con, regNum++, "R14_SVC", IR_R14_SVC);
      this->UpdateGridRow (con, regNum++, "R13_ABT", IR_R13_ABT);
      this->UpdateGridRow (con, regNum++, "R14_ABT", IR_R14_ABT);
      this->UpdateGridRow (con, regNum++, "R13_IRQ", IR_R13_IRQ);
      this->UpdateGridRow (con, regNum++, "R14_IRQ", IR_R14_IRQ);
      this->UpdateGridRow (con, regNum++, "R13_UND", IR_R13_UND);
      this->UpdateGridRow (con, regNum++, "R14_UND", IR_R14_UND);
      this->UpdateGridRow (con, regNum++, "CPSR", IR_CPSR);
      this->UpdateGridRow (con, regNum++, "SPSR_FIQ", IR_SPSR_FIQ);
      this->UpdateGridRow (con, regNum++, "SPSR_SVC", IR_SPSR_SVC);
      this->UpdateGridRow (con, regNum++, "SPSR_ABT", IR_SPSR_ABT);
      this->UpdateGridRow (con, regNum++, "SPSR_IRQ", IR_SPSR_IRQ);
      this->UpdateGridRow (con, regNum++, "SPSR_UND", IR_SPSR_UND);
      
      //////////////
      // Make a new row.
      wxString cond;
      
      cond = wxString::Format ("%s (%s)",  bits.Mid (0, 4), con->CPU ()->LastCond);
      grdDebug->InsertRows (grdDebug->GetRows ());
      grdDebug->SetCellValue (row, 0, cond);
      grdDebug->SetCellValue (row, 1, bits.Mid (4));
      grdDebug->SetCellValue (row, 2, con->CPU ()->LastResult);
      grdDebug->SetRowLabelValue (row, wxString::Format ("%d", row));
   }
   
   /////////////////////
   // Auto size columns.
   grdDebug->AutoSizeColumns ();
   grdCPUStatus->AutoSizeColumns ();
   //grdDebug->AutoSizeRowLabelSize (0);
   
   delete con;
}

void MainFrame::UpdateGridRow (Console* con, int row, wxString caption, InternalRegisterType reg)
{
   uint      regValue; 
   wxString  bits;
   wxString  hex;
   
   // Get the value of the register.
   regValue = *(con->CPU ()->REG->Reg (reg));
   
   // Turn it into a bit string.
   bits = UintToBitString (regValue);
   hex = UintToHexString (regValue);
   
   grdCPUStatus->SetCellValue (row, 0, caption);
   grdCPUStatus->SetCellTextColour (row, 0, wxColour (128, 128, 128));
   grdCPUStatus->SetCellValue (row, 1, wxString::Format ("%u", regValue));
   grdCPUStatus->SetCellValue (row, 2, bits);
   grdCPUStatus->SetCellValue (row, 3, hex);
}

void MainFrame::InitializeMenu ()
{
   wxMenuBar* mnuMain = new wxMenuBar ();
   wxMenu*    mnuFile = new wxMenu ();
   wxMenu*    mnuTools = new wxMenu ();
   wxMenu*    mnuHelp = new wxMenu ();
   
   this->SetMenuBar (mnuMain);
   
   //////////////////////
   // File menu
   mnuMain->Append (mnuFile, _T("&File"));
   mnuFile->Append (ID_MENU_FILE_OPENISO, _T("&Open ISO...\tCtrl+O"));
   mnuFile->AppendSeparator ();
   mnuFile->Append (ID_MENU_FILE_EXIT, _T("&Exit\tCtrl+X"));

   //////////////////////
   // Tools menu
   mnuMain->Append (mnuTools, _T("&Tools"));
   mnuTools->Append (ID_MENU_TOOLS_BROWSEISO, _T("&Browse ISO...\tCtrl+B"));
   mnuTools->Append (ID_MENU_TOOLS_VIEWCODE, _T("&View ARM60 Code"));
   
   //////////////////////
   // Help menu
   mnuMain->Append (mnuHelp, _T("&Help"));
   mnuHelp->Append (ID_MENU_HELP_ABOUT, _T("&About...\tShift+F1"));
}

/////////////////////////////////////////////////////////////////////////
// Event handlers
/////////////////////////////////////////////////////////////////////////
void MainFrame::OnMenuFileOpenISO (wxCommandEvent& WXUNUSED(event))
{
   wxString fileName = wxFileSelector (_T("Open 3DO ISO File"), NULL, NULL, NULL, _T("ISO Files (*.iso)|*.iso|All files (*.*)|*.*"), wxFD_OPEN | wxFD_FILE_MUST_EXIST);

   if (!fileName.empty())
   {
      wxMessageBox (wxString ("Nothing here yet. Try the browser."));
   }
}

void MainFrame::OnMenuFileExit (wxCommandEvent& WXUNUSED(event))
{
   this->Close ();
}

void MainFrame::OnMenuToolsBrowseISO (wxCommandEvent& WXUNUSED(event))
{
   this->BrowseIso ();
}

void MainFrame::OnMenuHelpAbout (wxCommandEvent& WXUNUSED(event))
{
   wxMessageBox (_T("FourDO - An Open-Source HLE 3DO Emulator\n\nVersion 0.0.0.1"), _T("About 4DO"), wxOK | wxICON_INFORMATION);
}

void MainFrame::OnMenuToolsViewCode (wxCommandEvent &WXUNUSED(event))
{
   wxString fileName = wxFileSelector (_T("Open ARM60 file"), NULL, NULL, NULL, _T("All files (*.*)|*.*"), wxFD_OPEN | wxFD_FILE_MUST_EXIST);
   
   if (!fileName.empty())
   {
      CodeViewer *codeViewer = new CodeViewer(this, fileName);
	  codeViewer->Show();
   }
}

void MainFrame::BrowseIso ()
{
   wxString fileName = wxFileSelector (_T("Open 3DO ISO File"), NULL, NULL, NULL, _T("ISO Files (*.iso)|*.iso|All files (*.*)|*.*"), wxFD_OPEN | wxFD_FILE_MUST_EXIST);
   
   if (!fileName.empty())
   {
      this->BrowseIso (fileName);
   }
}

void MainFrame::BrowseIso (wxString fileName)
{
   ISOBrowser* browser;
   browser = new ISOBrowser (this, fileName);
   browser->Show();
}
