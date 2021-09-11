<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    static void RegisterRoutes(RouteCollection routes)
    {
        //first param is unique, second param is the expected url, thrid param is the actual file/page
        //general root menu
        //Administrator
        routes.MapPageRoute("rtIndex", "index", "~/Default.aspx");
        routes.MapPageRoute("rtDashboard", "Dashboard", "~/Dashboard.aspx");
        routes.MapPageRoute("rtHome", "Home", "~/Default.aspx");
        routes.MapPageRoute("rten", "en", "~/Default.aspx");
        routes.MapPageRoute("rterror", "error", "~/Default.aspx");
        routes.MapPageRoute("rtSignin", "Signin", "~/Signin.aspx");
        routes.MapPageRoute("rtChangePassword", "changePassword", "~/changePassword.aspx");
        routes.MapPageRoute("rtAdm", "Admin", "~/Admin.aspx");


        //Administrator
        routes.MapPageRoute("rtAdminTeacherRegistration", "Teacher-Registration", "~/HenryAdm/TeachersRegistration.aspx");
        routes.MapPageRoute("rtNotVerifiedTeachers", "Not-Verified-Teachers", "~/HenryAdm/NotVerifiedTeachers.aspx");
        routes.MapPageRoute("rtNotAuthorizedPage", "504", "~/HenryAdm/NotAuthorizedPage.aspx");
        routes.MapPageRoute("rtVerifiedTeachers", "Verified-Teachers", "~/HenryAdm/VerifiedTeachers.aspx");
        routes.MapPageRoute("rtUploadResult", "Upload-Result", "~/HenryAdm/UploadResult.aspx");
        routes.MapPageRoute("rtMCDPForm", "MCDP-Form", "~/HenryAdm/MCDPForm.aspx");
        routes.MapPageRoute("rtAttendedToComplainForm", "Attended-Complain-Form", "~/HenryAdm/AttendedToComplainForm.aspx");
        routes.MapPageRoute("rtNotAttendedToComplainForm", "Not-Attended-Complain-Form", "~/HenryAdm/NotAttendedToComplainForm.aspx");
        routes.MapPageRoute("rtTRCNReport", "TRCN-Report", "~/HenryAdm/TRCNReport.aspx");
        routes.MapPageRoute("rtCertificateNotPrinteds", "Certificate-Not-Printed", "~/HenryAdm/CertificateNotPrinted.aspx");
        routes.MapPageRoute("rtPrintedCertificate", "Certificate-Printed", "~/HenryAdm/PrintedCertificate.aspx");
        routes.MapPageRoute("rtAuditTrail", "Audit-Trail", "~/HenryAdm/AuditTrail.aspx");
        routes.MapPageRoute("rtUserManagement", "User-Management", "~/HenryAdm/UserManagement.aspx");



        //Documentation
        routes.MapPageRoute("rtTeacherRegistration", "Teacher-Reg", "~/Documentation/TeacherRegistration.aspx");
        routes.MapPageRoute("rtDocument", "Document", "~/Documentation/Documentation.aspx");
        routes.MapPageRoute("rtDocumentVerifiedAccount", "Doc-Account-Verified", "~/Documentation/DocAccountVerified.aspx");
        routes.MapPageRoute("rtDocumentNotVerified", "Doc-Account-Not-Verified", "~/Documentation/docAccountNotVerified.aspx");


        //Account
        routes.MapPageRoute("rtAccount", "Account-Dashboard", "~/Account/Account.aspx");
        routes.MapPageRoute("rtAccountNotVerifiedTeachers", "Account-Not-Verified-Teachers", "~/Account/NotVerifiedTeachers.aspx");
         routes.MapPageRoute("rtAccountVerifiedTeachers", "Account-Verified-Teachers", "~/Account/VerifiedTeachers.aspx");
        
        //StateOffice
         routes.MapPageRoute("rtStateOffice", "StateOfficeAccount", "~/StateOffice/StateOffice.aspx");
         routes.MapPageRoute("rtUploadPictureAndSignatureLicensed", "Upload-Picture-And-Signature-Licensed", "~/StateOffice/UploadPictureAndSignatureLicensed.aspx");
         routes.MapPageRoute("rtUploadedPictureAndSignatureLogLicensed", "Uploaded-Picture-And-Signature-Log-Licensed", "~/StateOffice/UploadedPictureAndSignatureLogLicensed.aspx");
        routes.MapPageRoute("rtStateOfficeTeacherRegistration", "State-Office-Teacher-Registration", "~/StateOffice/StateOfficeTeacherRegistration.aspx");
        
        
        //Certificate

        routes.MapPageRoute("rtCertificates", "Cert", "~/Certificate/Certificate.aspx");
          routes.MapPageRoute("rtcertPrintedRecords", "certPrintedRecords", "~/Certificate/certPrintedRecords.aspx");
         routes.MapPageRoute("rtCertificateNotPrinted", "CertificateNotPrinted", "~/Certificate/CertificateNotPrinted.aspx");
       
        








    }
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
        //SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
    }

</script>
