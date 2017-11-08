/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.model;

import org.bson.types.ObjectId;
public class MessageView
{
    private ObjectId id;
    private String message;
    private String subject;
    private String sendDate;
    
    public ObjectId getId()
    {
        return id;
    }

    public void setId(ObjectId id)
    {
        this.id = id;
    }

    public String getMessage()
    {
        return message;
    }

    public void setMessage(String message)
    {
        this.message = message;
    }
    public String getSubject()
    {
        return subject;
    }

    public void setSubject(String subject)
    {
        this.subject = subject;
    }
    
    public String getSendDate()
    {
        return sendDate;
    }

    public void setSendDate(String sendDate)
    {
        this.sendDate = sendDate;
    }
}
