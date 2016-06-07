using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.Entities
{
    [Serializable]
    public class UsersInfo
    {
        // Fields
    private DateTime? _CreateTime;
    private string _EmailAddress;
    private DateTime? _LastLoginTime;
    private string _Password;
    private int? _Status;
    private int _UserID;
    private string _UserName;

    // Methods
    public UsersInfo()
    {
    
    }
    public UsersInfo(int _UserID, string _UserName, string _Password, DateTime? _LastLoginTime, string _EmailAddress, int? _Status, DateTime? _CreateTime)
{
    this._UserID = _UserID;
    this._UserName = _UserName;
    this._Password = _Password;
    this._LastLoginTime = _LastLoginTime;
    this._EmailAddress = _EmailAddress;
    this._Status = _Status;
    this._CreateTime = _CreateTime;
}

 

    // Properties
    public DateTime? CreateTime { get; set; }
    public string EmailAddress { get; set; }
    public DateTime? LastLoginTime { get; set; }
    public string Password { get; set; }
    public int? Status { get; set; }
    public int UserID { get; set; }
    public string UserName { get; set; }

    }
}
