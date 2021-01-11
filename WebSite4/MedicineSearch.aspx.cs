using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class MedicineSearch : System.Web.UI.Page
{
    protected ShoppingBag myShoppingBag;
    protected List<DataSet> presList;
    protected void Page_Load(object sender, EventArgs e)
    {
        //put the exit button in the menu
        //
        //EXIT BUTTON
        //the exit button will delete the user shopping bag(set the value to be null)
        //and doesnt change the current stock of the medicine.
        //
        //do a method that rrecives object, the session value of myShoppingbag will be an object
        //and a shopping bag variable.
        if (!Page.IsPostBack)
        {
            if (Session["myShoppingBag"] == null)
            {
                //create shopping list
                Session["myShoppingBag"] = new ShoppingBag();
            }
            else
            {
                myShoppingBag = (ShoppingBag)Session["myShoppingBag"];
            }
            if (Session["presList"] == null)
            {
                Session["presList"] = new List<DataSet>();
            }
            else
            {
                presList = (List<DataSet>)Session["presList"];
            }

            //put the catagorys and the producers in the DDL
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            DataSet pro = webser.GetProducer(), cat = webser.GetCatagory();
            List<ListItem> proList = GetAllData.getListItemsForDDL(pro, "MedicineProducer");
            List<ListItem> catList = GetAllData.getListItemsForDDL(cat, "MedicineCatagory");
            foreach (ListItem l in proList)
            {
                ProducerDDL.Items.Add(l);
            }
            foreach (ListItem l in catList)
            {
                DropDownListMedicineCatagory.Items.Add(l);
            }

        }
        CheckoutButton.Visible = true;
        SeeShoppingBag.Visible = true;
        User u = (User)Session["user"];
        if (u == null)
        {
            CheckoutButton.Visible = false;
            SeeShoppingBag.Visible = false;
        }
    }

    protected void SortButton_Click(object sender, EventArgs e)
    {
        table1.Visible = false;
        DataSet ds;
        string whereclout = "";
        string str = "qwertyuiopasdfghjkl;zxcvbnm|,./'[]{}\\`!@#$%^&*()_-+=*.<>QWERTYUIOPASDFGHJKLZXCVBNM";
        if (MoneyFrom.Text != "" || MoneyTo.Text != "")
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (MoneyFrom.Text.IndexOf(str[i]) != -1)
                {
                    Response.Write("<script>alert('טווח מחירים לא תקין')</script>");
                    return;
                }
                if (MoneyTo.Text.IndexOf(str[i]) != -1)
                {
                    Response.Write("<script>alert('טווח מחירים לא תקין')</script>");
                    return;
                }
            }
        }
        //init
        SearchReasultGrid.Visible = true;
        CloseMedicineGrid.Visible = true;
        //end init
        //creating the sort SQL line
        int pro = ProducerDDL.SelectedIndex + 1;
        int cat = DropDownListMedicineCatagory.SelectedIndex + 1;
        if (pro > 1)
        {
            if (whereclout != "")
            {
                whereclout = whereclout + " and ";
            }
            else
            {
                whereclout = " where ";
            }
            whereclout = whereclout + "MedicineProducer=" + pro;
        }
        if (cat > 1)
        {
            if (whereclout != "")
            {
                whereclout = whereclout + " and ";
            }
            else
            {
                whereclout = " where ";
            }
            whereclout = whereclout + "MedicineCatagory=" + cat;
        }
        if (MoneyFrom.Text != "")
        {
            if (whereclout != "")
            {
                whereclout = whereclout + " and ";
            }
            else
            {
                whereclout = " where ";
            }
            whereclout = whereclout + "MedicinePrice> " + Convert.ToInt32(MoneyFrom.Text);
        }
        if (MoneyTo.Text != "")
        {
            if (whereclout != "")
            {
                whereclout = whereclout + " and ";
            }
            else
            {
                whereclout = " where ";
            }
            whereclout = whereclout + "MedicinePrice< " + Convert.ToInt32(MoneyTo.Text);
        }
        string man = ManualSearch.Text;
        if (man != "")
        {
            if (whereclout != "")
            {
                whereclout = whereclout + " and ";
            }
            else
            {
                whereclout = " where ";
            }
            whereclout = whereclout + "(MedicineName LIKE '%" + man + "%')";
        }
        if (WithPresRB.Checked == true)
        {
            if (whereclout != "")
            {
                whereclout = whereclout + " and ";
            }
            else
            {
                whereclout = " where ";
            }
            whereclout = whereclout + "MedicineNeedPrescription=true";
        }
        if (WithoutPresRB.Checked == true)
        {
            if (whereclout != "")
            {
                whereclout = whereclout + " and ";
            }
            else
            {
                whereclout = " where ";
            }
            whereclout = whereclout + "MedicineNeedPrescription=false";
        }
        if (whereclout != "")
        {
            whereclout = whereclout + " and ";
        }
        else
        {
            whereclout = " where ";

        }
        whereclout = whereclout + "MedicineProducer=MedicineProducerId and MedicineCatagoryId=MedicineCatagory";

        Pharmcy.PharmcyWS web = new Pharmcy.PharmcyWS();
        ds = web.SortMedicine(whereclout);
        if (ds.Tables[0].Rows.Count == 0)
        {
            CloseMedicineGrid.Visible = false;
            Response.Write("<script>alert('לא נמצאו תרופות')</script>");
            CloseMedicineGrid_Click(sender, e);
            return;
        }
        SearchReasultGrid.DataSource = ds;
        SearchReasultGrid.DataBind();
        table1.Visible = true;

    }

    protected void CloseMedicineGrid_Click(object sender, EventArgs e)
    {
        table1.Visible = false;
        CloseMedicineGrid.Visible = false;
        SearchReasultGrid.Visible = false;
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        ManualSearch.Text = "";
        MoneyFrom.Text = "";
        MoneyTo.Text = "";
        DropDownListMedicineCatagory.SelectedIndex = 0;
        ProducerDDL.SelectedIndex = 0;
        CloseMedicineGrid_Click(sender, e);
        WithoutPresRB.Checked = false;
        WithPresRB.Checked = false;
    }

    protected void SearchReasultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddMedicine")
        {
            //check if the user is logged in, if not get him a message about it and redirect him to the regestrataion page
            User s = (User)Session["user"];
            if (s == null)
            {
                Response.Write("<script>alert('על מנת לרכוש מוצרים עליך להיות לקוח רשום')</script>");
                Response.Write("<script>window.open('http://localhost:49675/GuestHome.aspx','_blank');</script>");
                return;
            }

            //get the shopping bag
            myShoppingBag = (ShoppingBag)Session["myShoppingBag"];

            int rowNumber = Convert.ToInt32(e.CommandArgument);
            //create the medicineInBag var
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            MedicineInBag MIB = new MedicineInBag();
            MIB.CMedicineName = SearchReasultGrid.Rows[rowNumber].Cells[1].Text;
            MIB.CMedicineId = SearchReasultGrid.Rows[rowNumber].Cells[0].Text;
            MIB.CMedicinePrice = Convert.ToInt32(SearchReasultGrid.Rows[rowNumber].Cells[2].Text);
            MIB.CMedicineInBagMedicinePrice = Convert.ToInt32(MIB.CMedicinePrice);
            MIB.CMedicineNeedPrescription = Convert.ToBoolean(SearchReasultGrid.Rows[rowNumber].Cells[6].Text);
            MIB.CMedicineStock = Convert.ToInt32(SearchReasultGrid.Rows[rowNumber].Cells[3].Text);
            //same in MedicineCatagory
            MIB.CMedicineProducer = webser.GetMedicineProducer(Convert.ToInt32(MIB.CMedicineId));
            MIB.CMedicineCatagory = webser.GetMedicineCatagory(Convert.ToInt32(MIB.CMedicineId));
            DataSet temp = webser.GetMedicineCataAndProName(MIB.CMedicineCatagory, MIB.CMedicineProducer);
            MIB.CMedicineInBagCatagoryName = temp.Tables[0].Rows[0]["MedicineCatagoryName"].ToString();
            MIB.CMedicineInBagProducerName = temp.Tables[0].Rows[0]["MedicineProducerName"].ToString();

            ///////////////////////////////////////////////////////////////////////////////////
            //check count of medicine
            //because we didnt change the current stock of the medicine we need to check if there is 
            //enough from this medicine to buy
            int countOfMedicine = myShoppingBag.GetMedicineCount(Convert.ToInt32(MIB.CMedicineId));
            User u = (User)Session["user"];
            if (MIB.CMedicineStock - countOfMedicine <= 0)
            {
                Response.Write("<script>alert('אין מספיק תרופות במלאי')</script>");
                return;
            }

            ///////////////////////////////////////////////////////////////////////////////////

            //check prescription
            int MedIdNumber = Convert.ToInt32(MIB.CMedicineId);
            //still dont change the current stock of medicine
            if (MIB.CMedicineNeedPrescription)
            {
                PrescriptioService ps = new PrescriptioService();
                DataSet ds = ps.GetPrescriptionByMedicineId(MedIdNumber, u.CUserId);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script>alert('תרופה זאת צריכה מרשם')</script>");
                    return;
                }
                else
                {
                    //לבדוק אם הוא באמת הכניס אותה כמות
                    //אם הוא הכניס אותה כמות אז הכל בסדר
                    //צריך לזכור לבטל את המרשם ברגע שהקנייה מתבצעת
                    //אם הכמות לא שווה אז ליידע את הלקוח שהוא צריך לבדוק כמה כדורים נתנו לו
                    //אפשרות לחשוף קישור בדף לעמוד של המרשמים כדי שיוכל להסתכל
                    //או שאפשר להגיד למשתמש כמה כדורים הוא יכול לקחת(מעדיף שלא נשמע קצת מוזר)
                    presList = (List<DataSet>)Session["presList"];
                    if (presList != null)
                    {
                        foreach (DataSet d in presList)
                        {
                            if (ds.Tables[0].Rows[0]["PrescriptionId"].ToString() == d.Tables[0].Rows[0]["PrescriptionId"].ToString())
                            {
                                Response.Write("<script>alert('מרשם זה כבר שומש')</script>");
                                return;
                            }
                        }
                    }
                    presList.Add(ds);
                    Session["presList"] = presList;
                    int count = Convert.ToInt32(ds.Tables[0].Rows[0]["PrescriptionMedicineCount"].ToString());
                    MIB.CMedicineInBagMedicineCount = count;
                }
            }
            else
            {
                MIB.CMedicineInBagMedicineCount = 1;
            }
            myShoppingBag.AddMedicine(MIB);
            Session["myShoppingBag"] = myShoppingBag;
            Response.Write("<script>alert('המוצר הוסף לסל')</script>");
            CheckoutButton.Visible = true;
            SeeShoppingBag.Visible = true;
        }

    }

    protected void CheckoutButton_Click(object sender, EventArgs e)
    {
        User temp = (User)Session["user"];
        if (temp == null)
        {
            Response.Write("<script>alert('על מנת לרכוש מוצרים עליך להיות לקוח רשום')</script>");
            Response.Write("<script>window.open('http://localhost:49675/GuestHome.aspx');</script>");
            return;
        }
        ShoppingBag sb = (ShoppingBag)Session["myShoppingBag"];
        if (sb == null || sb.isEmpty())
        {
            Response.Write("<script>alert('הסל ריק')</script>");
            return;
        }
        //delete all the prescription from database
        presList = (List<DataSet>)Session["presList"];
        int presId;
        PrescriptioService ps = new PrescriptioService();
        if (presList != null)
        {
            foreach (DataSet d in presList)
            {
                presId = Convert.ToInt32(d.Tables[0].Rows[0]["PrescriptionId"].ToString());
                ps.DeletePrescription(presId);
            }
        }
        //update all the medicine stock according to the current count
        Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
        int totalPrice = sb.GetTotalPrice();
        List<MedicineInBag> medList = sb.GetProducts();
        int countOfMedicine = 0, size = sb.getSize(), index = 0;
        //create medicineInBag variables
        string[] id = new string[size], name = new string[size], pn = new string[size], cn = new string[size];
        int[] price = new int[size], s = new int[size], pro = new int[size], cat = new int[size], count = new int[size];
        bool[] p = new bool[size];
        foreach (MedicineInBag m in medList)
        {
            id[index] = m.CMedicineId;
            name[index] = m.CMedicineName;
            pn[index] = m.CMedicineInBagProducerName;
            cn[index] = m.CMedicineInBagCatagoryName;
            price[index] = m.CMedicinePrice;
            s[index] = m.CMedicineStock;
            pro[index] = m.CMedicineProducer;
            cat[index] = m.CMedicineCatagory;
            p[index] = m.CMedicineNeedPrescription;
            count[index] = m.CMedicineInBagMedicineCount;
            index++;

           
            /////////////////////////////////////////////////////////////////////////
            /*
            int currentStock = webser.GetMedicineStock(Convert.ToInt32(m.CMedicineId));
            countOfMedicine = currentStock - m.CMedicineInBagMedicineCount;
            webser.UpdateMedCount(countOfMedicine,Convert.ToInt32(m.CMedicineId));
            */
            //////////////////////////////////////////////////////////////////////////
        }
        //inseat to data base
        User u = (User)Session["user"];
        /*
        
        ///////////
        os.InsertOrder(o);
        ////////////////
        ///*/
        ////////////////////////////////////////////////////////////////////////////
        webser.InseartOrder(id, name, price, p, s, pro, cat, pn, cn, count, u.CUserId);
        ////////////////////////////////////////////////////////////////////////////

        //init the shopping bag and the prescription list
        presList = new List<DataSet>();
        Session["presList"] = new List<DataSet>();
        sb = new ShoppingBag();
        Session["myShoppingBag"] = new ShoppingBag();
        Response.Write("<script>alert('ההזמנה בוצעה בהצלחה, עלות ההזמנה היא: " + totalPrice + " שקלים')</script>");
        SortButton_Click(sender, e);
    }

    protected void SearchReasultGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void SeeShoppingBag_Click(object sender, EventArgs e)
    {
        User temp = (User)Session["user"];
        if (temp == null)
        {
            Response.Write("<script>alert('על מנת לרכוש מוצרים עליך להיות לקוח רשום')</script>");
            Response.Write("<script>window.open('http://localhost:49675/GuestHome.aspx');</script>");
            return;
        }
        ShoppingBag sb = (ShoppingBag)Session["myShoppingBag"];
        if (sb == null || sb.isEmpty())
        {
            Response.Write("<script>alert('הסל ריק')</script>");
            return;
        }
        Response.Write("<script>window.open('http://localhost:49675/UserShoppingBag.aspx','_blank');</script>");
    }

    protected void SearchReasultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchReasultGrid.PageIndex = e.NewPageIndex;
        SortButton_Click(sender, e);
    }


    protected void WithoutPresRB_CheckedChanged(object sender, EventArgs e)
    {
        WithPresRB.Checked = false;
    }

    protected void WithPresRB_CheckedChanged(object sender, EventArgs e)
    {
        WithoutPresRB.Checked = false;
    }
}