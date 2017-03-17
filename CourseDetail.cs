using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for CourseDetail
/// </summary>
public class CourseDetail
{
    String CID, Cc1,Cc2,Cres,log ,err;

	int Cnof,Cterm;
    decimal CL, CT, CP, CLTP,Ca,Cb,Ccd;
    public String Login
    {
        get
        {
            return log;
        }

        set
        {
            log = value;
        }
    }
    public String Error
    {
        get
        {
            return err;
        }

        set
        {
            err = value;
        }
    }
    public int CourseTerm
    {
        get
        {
            return Cterm;
        }

        set
        {
            Cterm = value;
        }
    }
    public String CourseID
    {
        get
        {
            return CID;
        }

        set
        {
            CID = value;
        }
    }
    public decimal CourseL
    {
        get
        {
            return CL;
        }

        set
        {
            CL = value;
        }
    }
    public decimal CourseT
    {
        get
        {
            return CT;
        }

        set
        {
            CT = value;
        }
    }
    public decimal CourseP
    {
        get
        {
            return CP;
        }

        set
        {
            CP = value;
        }
    }
    public decimal CourseLTP
    {
        get
        {
            return CLTP;
        }

        set
        {
            CLTP = value;
        }
    }
    public int CourseNOF
    {
        get
        {
            return Cnof;
        }

        set
        {
            Cnof = value;
        }
    }

    public decimal CourseA
    {
        get
        {
            return Ca;
        }

        set
        {
            Ca = value;
        }
    }
    public decimal CourseB
    {
        get
        {
            return Cb;
        }

        set
        {
            Cb = value;
        }
    }
    public decimal CourseD
    {
        get
        {
            return Ccd;
        }

        set
        {
            Ccd = value;
        }
    }
    
    public String CourseCc1
    {
        get
        {
            return Cc1;
        }

        set
        {
            Cc1 = value;
        }
    }
    public String CourseCc2
    {
        get
        {
            return Cc2;
        }

        set
        {
            Cc2 = value;
        }
    }

    public String CourseRst
    {
        get
        {
            return Cres;
        }

        set
        {
            Cres = value;
        }
    }
    public static DataTable Courses(int term, String log)
    {
        String cns = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Saurabh\Desktop\Appraisal\App_Data\Database.mdf;Integrated Security=True";
       String cms = "Select * from CourseS where term=" + term + " and login='" + log + "'" ;
       SqlDataAdapter da=new SqlDataAdapter(cms,cns);
        DataSet ds=new DataSet();
        da.Fill(ds);
        return ds.Tables[0];
    }
    public String IsEntered()
    {

        try
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Saurabh\Desktop\Appraisal\App_Data\Database.mdf;Integrated Security=True";
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(*) from CourseS where login=@log and term=@term and CourseID=@cid";
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@log", log);
            cm.Parameters.AddWithValue("@term", Cterm);
            cm.Parameters.AddWithValue("@cid", CID);

            int count = (int)cm.ExecuteScalar();
            if (count > 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }

        }
        catch (Exception e1)
        {
            err = e1.Message;
            return "no";
        }

    }
    public bool NewCourseD()
    {
        bool res = false;
        try
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Saurabh\Desktop\Appraisal\App_Data\Database.mdf;Integrated Security=True";
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "insert into CourseS values(@log,@ter,@cid,@cl,@ct,@cp,@cltp,@cnof,@ca,@cb,@cc1,@cc2,@cres,@ccd)";
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@log", log);
            cm.Parameters.AddWithValue("@ter", Cterm);
            cm.Parameters.AddWithValue("@cid", CID);
            cm.Parameters.AddWithValue("@cl", CL);
            cm.Parameters.AddWithValue("@ct", CT);
            cm.Parameters.AddWithValue("@cp", CP);
            cm.Parameters.AddWithValue("@cltp", CLTP);
            cm.Parameters.AddWithValue("@cnof", Cnof);
            cm.Parameters.AddWithValue("@ca", Ca);
            cm.Parameters.AddWithValue("@cb", Cb);
            cm.Parameters.AddWithValue("@cc1", Cc1);
            cm.Parameters.AddWithValue("@cc2", Cc2);
            cm.Parameters.AddWithValue("@cres", Cres);
            cm.Parameters.AddWithValue("@ccd", Ccd);
            int c = cm.ExecuteNonQuery();
            if (c > 0)
            {
                res = true;
            }
        }
        catch (Exception e)
        {
            err = e.Message;
            res = false;
        }
        return res;
    }
    public bool UpdateCourseD()
    {
        bool res = false;
        try
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Saurabh\Desktop\Appraisal\App_Data\Database.mdf;Integrated Security=True";
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "update CourseS set CL=@cl,CT=@ct,CP=@cp,CLTP=@cltp,cnof=@cnof,Ca=@ca,Cb=@cb,Cc1=@cc1,Cc2=@cc2,Cres=@cres,Ccd=@ccd where login=@log and term=@ter and courseid=@cid";
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@cl", CL);
            cm.Parameters.AddWithValue("@ct", CT);
            cm.Parameters.AddWithValue("@cp", CP);
            cm.Parameters.AddWithValue("@cltp", CLTP);
            cm.Parameters.AddWithValue("@cnof", Cnof);
            cm.Parameters.AddWithValue("@ca", Ca);
            cm.Parameters.AddWithValue("@cb", Cb);
            cm.Parameters.AddWithValue("@cc1", Cc1);
            cm.Parameters.AddWithValue("@cc2", Cc2);
            cm.Parameters.AddWithValue("@cres", Cres);
            cm.Parameters.AddWithValue("@ccd", Ccd);
            cm.Parameters.AddWithValue("@log", log);
            cm.Parameters.AddWithValue("@ter", Cterm);
            cm.Parameters.AddWithValue("@cid", CID);
            
            int c = cm.ExecuteNonQuery();
            if (c > 0)
            {
                res = true;
            }
        }
        catch (Exception e)
        {
            err = e.Message;
            res = false;
        }
        return res;
    }
	public CourseDetail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}