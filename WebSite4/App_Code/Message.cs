using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message  // יש בעיה עם המפתח  הראשי צריך לסדר
{ //need to add answer writing time and change MessageDate to MessageSendDate, also change in Data base
    private int MessageId;
    private string MessageUserId;
    private string MessageDoctorId;
    private string MessageManagerId;
    private string MessageContent;
    private string MessageTheme;
    private string MessageAnswer;
    private DateTime MessageSendDate;
    private DateTime MessageAnswerDate;
    private string MessageWhoSent;
    public Message()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string CMessageUserId
    {
        get
        {
            return this.MessageUserId;
        }
        set
        {
            this.MessageUserId = value;
        }
    }
    public string CMessageAnswer
    {
        get
        {
            return this.MessageAnswer;
        }
        set
        {
            this.MessageAnswer = value;
        }
    }
    public string CMessageTheme
    {
        get
        {
            return this.MessageTheme;
        }
        set
        {
            this.MessageTheme = value;
        }
    }
    public string CMessageDoctorId
    {
        get
        {
            return this.MessageDoctorId;
        }
        set
        {
            this.MessageDoctorId = value;
        }
    }
    public string CMessageContent
    {
        get
        {
            return this.MessageContent;
        }
        set
        {
            this.MessageContent = value;
        }
    }
    public DateTime CMessageSendDate
    {
        get
        {
            return this.MessageSendDate;
        }
        set
        {
            this.MessageSendDate = value;
        }
    }
    public DateTime CMessageAnswerDate
    {
        get
        {
            return this.MessageAnswerDate;
        }
        set
        {
            this.MessageAnswerDate = value;
        }
    }
    public int CMessageId
    {
        get
        {
            return this.MessageId;
        }
        set
        {
            this.MessageId = value;
        }
    }
    public string CMessageManagerId
    {
        get
        {
            return this.MessageManagerId;
        }
        set
        {
            this.MessageManagerId = value;
        }
    }
    public string CMessageWhoSent
    {
        get
        {
            return MessageWhoSent;
        }
        set
        {
            this.MessageWhoSent = value;
        }
    }
}