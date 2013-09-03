using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Text;


public partial class Asset_AddAsset : System.Web.UI.Page
{
    Asset_mst objasset = new Asset_mst();
    Asset_ProductInfo_mst objproinfo = new Asset_ProductInfo_mst();
    Asset_Processor_mst objprocessor = new Asset_Processor_mst();
    Asset_Memory_mst objmemory = new Asset_Memory_mst();
    Asset_Network_mst objnetwork = new Asset_Network_mst();
    Asset_OperatingSystem_mst objoperating = new Asset_OperatingSystem_mst();
    Asset_PhysicalDrive_mst objphydrive = new Asset_PhysicalDrive_mst();
    Asset_LogicalDrive_mst objlogicdrive = new Asset_LogicalDrive_mst();
    Asset_Inventory_mst objinventory = new Asset_Inventory_mst();
    public string[] filenames;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValComputerName.ErrorMessage = Resources.MessageResource.errcompname.ToString();
            reqValProductName.ErrorMessage = Resources.MessageResource.errproduct.ToString();
            reqValProductManufacturer.ErrorMessage = Resources.MessageResource.errproductmanufacturer.ToString();
            reqValProductSerialno.ErrorMessage = Resources.MessageResource.errserialno.ToString();
            reqValProcessorname.ErrorMessage = Resources.MessageResource.errprocessor.ToString();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();
        
    }
    protected void btnAdd_click(object sender, EventArgs e)
    {
        lblerrmsg.Text = "";
        int varassetid, compcount;
        string comname,domain;
        comname = txtcomputername.Text.ToString();
        domain = txtdomain.Text.ToString();
        compcount = objasset.Get_ComputerName(comname, domain);

        if (compcount == 0)
        {
            //insert Deatils for Asset_mst
            objasset.Computername = txtcomputername.Text.ToString();
            objasset.Domain = txtdomain.Text.ToString();
            //objasset.Createdatetime = lbldate.Text.ToString();
            objasset.Insert1();
            //Details for ProductInfo_mst
            varassetid = objasset.Get_Current_Assetid();
            objproinfo.Assetid = varassetid;
            objproinfo.Product_manufacturer = txtprocmanufacturer.Text.ToString();
            objproinfo.Product_name = txtproductname.Text.ToString();
            objproinfo.Serial_number = txtproductsno.Text.ToString();
            objproinfo.Sku_no = txtskuno.Text.ToString();
            objproinfo.Uuid = txtuuid.Text.ToString();
            //Details for Prcessor_mst
            objprocessor.Assetid = varassetid;
            objprocessor.Family = txtfamily.Text.ToString();
            objprocessor.Manufacturer = txtprocmanufacturer.Text.ToString();
            objprocessor.Max_speed = txtmaxspeed.Text.ToString();
            objprocessor.Model = txtmodel.Text.ToString();
            objprocessor.Processor_name = txtprocessorname.Text.ToString();
            objprocessor.Speed = txtspeed.Text.ToString();
            objprocessor.Stepping = txtstepping.Text.ToString();
            //Details for Memory_mst
            objmemory.Assetid = varassetid;
            objmemory.Page_file = txtpagefile.Text.ToString();
            objmemory.Physical_mem = txtphysicalmemory.Text.ToString();
            objmemory.Virtual_mem = txtvirtualmemory.Text.ToString();
            //Details for Network_mst
            objnetwork.Adapter_name = txtadaptername.Text.ToString();
            objnetwork.Assetid = varassetid;
            objnetwork.Gateway = txtgateway.Text.ToString();
            objnetwork.Ip_address = txtipaddress.Text.ToString();
            objnetwork.Link_speed = txtlinkspeed.Text.ToString();
            objnetwork.Mac_address = txtmacaddress.Text.ToString();
            objnetwork.Mtu = txtmtu.Text.ToString();
            objnetwork.Protocol_name = txtprotocol.Text.ToString();
            objnetwork.Subnet_mask = txtsubnet.Text.ToString();
            objnetwork.Type = txttype.Text.ToString();
            // Details of Operating System
            objoperating.Add_info = txtaddinfo.Text.ToString();
            objoperating.Assetid = varassetid;
            objoperating.Build_no = txtbuildno.Text.ToString();
            objoperating.Localization = txtlocal.Text.ToString();
            objoperating.Major_version = txtmajorversion.Text.ToString();
            objoperating.Minor_version = txtminorversion.Text.ToString();
            objoperating.Os_name = txtosname.Text.ToString();
            objoperating.Product_key = txtprokey.Text.ToString();
            objoperating.Reg_code = txtregcode.Text.ToString();
            objoperating.Reg_org = txtregorg.Text.ToString();
            objoperating.Reg_to = txtregto.Text.ToString();
            objoperating.User_name = txtusername1.Text.ToString();
            //Details of Physical Drive
            objphydrive.Assetid = varassetid;
            objphydrive.Capacity = txtcapacity.Text.ToString();
            objphydrive.Drive_name = txtdrivename.Text.ToString();
            objphydrive.Manufacturer = txtmanufacturer.Text.ToString();
            objphydrive.Product_id = txtproductid.Text.ToString();
            objphydrive.Product_version = txtproductversion.Text.ToString();
            objphydrive.Serial_number = txtserialno.Text.ToString();
            //Details of Logical Drive
            objlogicdrive.Assetid = varassetid;
            objlogicdrive.Drive_letter = txtdriveletter.Text.ToString();
            objlogicdrive.Drive_type = txtdrivetype.Text.ToString();
            objlogicdrive.File_system_name = txtfilesysname.Text.ToString();
            objlogicdrive.Free_bytes = txtfreebytes.Text.ToString();
            objlogicdrive.Total_bytes = txttotalbytes.Text.ToString();
            //Details of Inventory
            objinventory.Assetid = varassetid;
            objinventory.Computername = txtcomputername.Text.ToString();

            //Insert functions
            objproinfo.Insert1();
            objprocessor.Insert1();
            objmemory.Insert1();
            objnetwork.Insert1();
            objoperating.Insert1();
            objphydrive.Insert1();
            objlogicdrive.Insert1();
            objinventory.Insert1();

            #region Create XML File
            // Section for Create new XML file

            //string compane;
            //comname = txtcomputername.Text.ToString();

            XmlTextWriter textWriter = new XmlTextWriter("C:\\Asset\\Data\\" + comname + ".xml", null);

            
            // Opens the document
            textWriter.WriteStartDocument();
            

            textWriter.WriteStartElement("Computer");
            textWriter.WriteStartElement("Computer_name");
            textWriter.WriteString(txtcomputername.Text.ToString());
            textWriter.WriteEndElement();//End Computer_name

            textWriter.WriteStartElement("Domain");
            textWriter.WriteString(txtdomain.Text.ToString());
            textWriter.WriteEndElement();//End Domain

            textWriter.WriteStartElement("Created_on");
            textWriter.WriteString(DateTime.Now.ToString());
            textWriter.WriteEndElement();//End CreatedOn

            textWriter.WriteStartElement("Hardware");
            textWriter.WriteStartElement("Product_details");
            textWriter.WriteStartElement("Name");
            textWriter.WriteString(txtproductname.Text.ToString());
            textWriter.WriteEndElement();//End Name

            textWriter.WriteStartElement("Manufacturer");
            textWriter.WriteString(txtproductmanufacture.Text.ToString());
            textWriter.WriteEndElement();//End Manufacturer

            textWriter.WriteStartElement("Serial_number");
            textWriter.WriteString(txtproductsno.Text.ToString());
            textWriter.WriteEndElement();//End Serial number

            textWriter.WriteStartElement("UUID");
            textWriter.WriteString(txtuuid.Text.ToString());
            textWriter.WriteEndElement();//End Uuid

            textWriter.WriteStartElement("SKU_number");
            textWriter.WriteString(txtskuno.Text.ToString());
            textWriter.WriteEndElement();//End SKU Number
            textWriter.WriteEndElement();//End Product Details

            textWriter.WriteStartElement("Processors");
            textWriter.WriteStartElement("Family");
            textWriter.WriteString(txtfamily.Text.ToString());
            textWriter.WriteEndElement();//End Family

            textWriter.WriteStartElement("Manufacturer");
            textWriter.WriteString(txtprocmanufacturer.Text.ToString());
            textWriter.WriteEndElement();//End Manufacturer

            textWriter.WriteStartElement("Max_speed");
            textWriter.WriteString(txtmaxspeed.Text.ToString());
            textWriter.WriteEndElement();//End Max Speed

            textWriter.WriteStartElement("Model");
            textWriter.WriteString(txtmodel.Text.ToString());
            textWriter.WriteEndElement();//End Model

            textWriter.WriteStartElement("Processor");
            textWriter.WriteString(txtprocessorname.Text.ToString());
            textWriter.WriteEndElement();//End Processor

            textWriter.WriteStartElement("Speed");
            textWriter.WriteString(txtspeed.Text.ToString());
            textWriter.WriteEndElement();//End Speed

            textWriter.WriteStartElement("Stepping");
            textWriter.WriteString(txtstepping.Text.ToString());
            textWriter.WriteEndElement();//End Stepping
            textWriter.WriteEndElement();//End Processors

            textWriter.WriteStartElement("Memory");
            textWriter.WriteStartElement("Physical_memory");
            textWriter.WriteString(txtphysicalmemory.Text.ToString());
            textWriter.WriteEndElement();//End Physical Memory

            textWriter.WriteStartElement("Virtual_memory");
            textWriter.WriteString(txtvirtualmemory.Text.ToString());
            textWriter.WriteEndElement();//End Virtual Memory

            textWriter.WriteStartElement("Page_file_size");
            textWriter.WriteString(txtpagefile.Text.ToString());
            textWriter.WriteEndElement();//End Page File Size
            textWriter.WriteEndElement();//End Memory

            textWriter.WriteStartElement("Physical_drives");
            textWriter.WriteStartElement("Drive");
            textWriter.WriteString(txtdrivename.Text.ToString());
            textWriter.WriteEndElement();//End Drive

            textWriter.WriteStartElement("Capacity");
            textWriter.WriteString(txtcapacity.Text.ToString());
            textWriter.WriteEndElement();//End Capacity

            textWriter.WriteStartElement("Manufacturer");
            textWriter.WriteString(txtmanufacturer.Text.ToString());
            textWriter.WriteEndElement();//End Manufacturer

            textWriter.WriteStartElement("Serial_number");
            textWriter.WriteString(txtserialno.Text.ToString());
            textWriter.WriteEndElement();//End Serial Number
            textWriter.WriteEndElement();//Physical Drive

            textWriter.WriteStartElement("Logical_drives");
            textWriter.WriteStartElement("Drive_letter");
            textWriter.WriteString(txtdriveletter.Text.ToString());
            textWriter.WriteEndElement();//End Drive Letter

            textWriter.WriteStartElement("Drive_type");
            textWriter.WriteString(txtdrivetype.Text.ToString());
            textWriter.WriteEndElement();//End Drive Type

            textWriter.WriteStartElement("File_system_name");
            textWriter.WriteString(txtfilesysname.Text.ToString());
            textWriter.WriteEndElement();//End File System Name

            textWriter.WriteStartElement("Free_bytes");
            textWriter.WriteString(txtfreebytes.Text.ToString());
            textWriter.WriteEndElement();//End Free Bytes

            textWriter.WriteStartElement("Total_bytes");
            textWriter.WriteString(txttotalbytes.Text.ToString());
            textWriter.WriteEndElement();//End Total Bytes
            textWriter.WriteEndElement();//Logical_drives
            textWriter.WriteEndElement();//Hardware


            textWriter.WriteStartElement("General_info");
            textWriter.WriteStartElement("Operating_system");
            textWriter.WriteStartElement("Name");
            textWriter.WriteString(txtosname.Text.ToString());
            textWriter.WriteEndElement();//End Name

            textWriter.WriteStartElement("Major_version");
            textWriter.WriteString(txtmajorversion.Text.ToString());
            textWriter.WriteEndElement();//End Major Version

            textWriter.WriteStartElement("Minor_version");
            textWriter.WriteString(txtminorversion.Text.ToString());
            textWriter.WriteEndElement();//End Minor Version

            textWriter.WriteStartElement("Build_number");
            textWriter.WriteString(txtbuildno.Text.ToString());
            textWriter.WriteEndElement();//End Build Number

            textWriter.WriteStartElement("Additional_information");
            textWriter.WriteString(txtaddinfo.Text.ToString());
            textWriter.WriteEndElement();//End Additional Information

            textWriter.WriteStartElement("User_name");
            textWriter.WriteString(txtusername1.Text.ToString());
            textWriter.WriteEndElement();//End User Name

            textWriter.WriteStartElement("Registered_to");
            textWriter.WriteString(txtregto.Text.ToString());
            textWriter.WriteEndElement();//End Registerd To

            textWriter.WriteStartElement("Registered_organization");
            textWriter.WriteString(txtregorg.Text.ToString());
            textWriter.WriteEndElement();//End Registered Organization

            textWriter.WriteStartElement("Registration_code");
            textWriter.WriteString(txtregcode.Text.ToString());
            textWriter.WriteEndElement();//End Registration Code

            textWriter.WriteStartElement("Locale");
            textWriter.WriteString(txtlocal.Text.ToString());
            textWriter.WriteEndElement();//End Localization

            textWriter.WriteStartElement("Product_key");
            textWriter.WriteString(txtprokey.Text.ToString());
            textWriter.WriteEndElement();//End Product Key
            textWriter.WriteEndElement();//Operating System
            textWriter.WriteEndElement();//General Info


            textWriter.WriteStartElement("Network_adapters");
            textWriter.WriteStartElement("Adapter");
            textWriter.WriteStartElement("Network_protocols");
            textWriter.WriteStartElement("Protocol");
            textWriter.WriteStartElement("IP_Addresses");
            textWriter.WriteStartElement("Address");
            textWriter.WriteString(txtipaddress.Text.ToString());
            textWriter.WriteEndElement();//Address
            textWriter.WriteEndElement();//IP_Address

            textWriter.WriteStartElement("Gateways");
            textWriter.WriteString(txtgateway.Text.ToString());
            textWriter.WriteEndElement();//Gateways

            textWriter.WriteString(txtprotocol.Text.ToString());
            textWriter.WriteEndElement();//Protocol
            textWriter.WriteEndElement();//Network_protocols

            textWriter.WriteString(txtadaptername.Text.ToString());
            textWriter.WriteEndElement();//Adapter

            textWriter.WriteStartElement("Link_speed");
            textWriter.WriteString(txtlinkspeed.Text.ToString());
            textWriter.WriteEndElement();//Link_speed
            textWriter.WriteEndElement();//Network_adapters
            textWriter.WriteEndElement();//Network_adapters

            textWriter.WriteEndDocument();
            textWriter.Close();

            // End Section
            #endregion
            //string nodename="Computer Name";
            //XDocument xmldoc = XDocument.Load("C:\\Asset\\Asset.xml");
            //xmldoc.Element("Computers").Add(new XElement(nodename, txtcomputername.Text));
            //xmldoc.Save("C:\\Asset\\Asset.xml");

            Response.Redirect("../Asset/ViewAssetDetails.aspx?" + comname + "");


            //Clear();
            //lblerrmsg.Text = "Insert Succussfully";
        }
        else
        {
            txtcomputername.Text = "";
            lblerrmsg.Text = "Computer Name Already Exist";

        }
    }



    protected void Clear()
    {
        lblerrmsg.Text = "";
        txtadaptername.Text = "";
        txtaddinfo.Text = "";
        txtbuildno.Text = "";
        txtcapacity.Text = "";
        txtcomputername.Text = "";
        txtdomain.Text = "";
        txtdriveletter.Text = "";
        txtdrivename.Text = "";
        txtdrivetype.Text = "";
        txtvirtualmemory.Text = "";
        txtfamily.Text = "";
        txtfilesysname.Text = "";
        txtfreebytes.Text = "";
        txtgateway.Text = "";
        txtipaddress.Text = "";
        txtlinkspeed.Text = "";
        txtlocal.Text = "";
        txtmacaddress.Text = "";
        txtmajorversion.Text = "";
        txtmanufacturer.Text = "";
        txtmaxspeed.Text = "";
        txtminorversion.Text = "";
        txtmodel.Text = "";
        txtmtu.Text = "";
        txtosname.Text = "";
        txtpagefile.Text = "";
        txtprocessorname.Text = "";
        txtprocmanufacturer.Text = "";
        txtproductid.Text = "";
        txtproductmanufacture.Text = "";
        txtproductname.Text = "";
        txtproductsno.Text = "";
        txtproductversion.Text = "";
        txtprokey.Text = "";
        txtprotocol.Text = "";
        txtregcode.Text = "";
        txtregorg.Text = "";
        txtregto.Text = "";
        txtserialno.Text = "";
        txtskuno.Text = "";
        txtspeed.Text = "";
        txtstepping.Text = "";
        txtsubnet.Text = "";
        txttotalbytes.Text = "";
        txttype.Text = "";
        txtphysicalmemory.Text = "";
        txtusername1.Text = "";
        txtuuid.Text = "";

    }
}
