using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SyllabusQ
/// </summary>
public class SyllabusQ
{
    private String log, remark,err;
    private int term;
    private decimal scerti, hcerti, pntawd;
	public SyllabusQ()
	{
		
	}
    public String Error
    {
        get
        {
            return err;
        }
    }

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
    public String Remarks
    {
        get
        {
            return remark;
        }
        set
        {
            remark = value;
        }
    }
    public int Term
    {
        get
        {
            return term;
        }
        set
        {
            term = value;
        }
    }

    public decimal SelfCerti
    {
        get
        {
            return scerti;
        }
        set
        {
            scerti = value;
        }
    }
    public decimal HodCerti
    {
        get
        {
            return hcerti;
        }
        set
        {
            hcerti = value;
        }
    }
    public decimal Pointsawt
    {
        get
        {
            return pntawd;
        }
        set
        {
            pntawd = value;
        }
    }
    public  DataTable UserSyllabus()
    {
        String cns = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Saurabh\Desktop\Appraisal\App_Data\Database.mdf;Integrated Security=True";
        String cms = "Select * from SyllabusQuality where login='" + log +"' order by Term" ;
        SqlDataAdapter da = new SqlDataAdapter(cms, cns);
        DataSet ds = new DataSet();
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
            cm.CommandText = "select count(*) from SyllabusQuality where login=@log and term=@term";
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@log", log);
            cm.Parameters.AddWithValue("@term", term);

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
    public bool NewSyllabusQ()
    {
        bool res = false;
        try
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Saurabh\Desktop\Appraisal\App_Data\Database.mdf;Integrated Security=True";
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "insert into SyllabusQuality values(@log,@term,@selfcerti,@hodcerti,@pointsawd,@remarks)";
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@log", log);
            cm.Parameters.AddWithValue("@term", term);
            cm.Parameters.AddWithValue("@selfcerti", scerti);
            cm.Parameters.AddWithValue("@hodcerti", hcerti);
            cm.Parameters.AddWithValue("@pointsawd", pntawd);
            cm.Parameters.AddWithValue("@remarks", remark);

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
    public bool UpdateSyllabusQ()
    {
        bool res = false;
        try
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Administrator\Documents\Visual Studio 2010\WebSites\Appraisal\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "update SyllabusQuality set Selfcerti=@selfcerti,hodcerti=@hodcerti,pointsawd=@pointsawd,remarks=@remarks where login=@log and Term=@term";
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@selfcerti", scerti);
            cm.Parameters.AddWithValue("@hodcerti", hcerti);
            cm.Parameters.AddWithValue("@pointsawd", pntawd);
            cm.Parameters.AddWithValue("@remarks", remark);
            cm.Parameters.AddWithValue("@log", log);
            cm.Parameters.AddWithValue("@term", term);
            
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


}