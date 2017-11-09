/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.model;
import org.mongodb.morphia.annotations.Entity;
import org.mongodb.morphia.annotations.Reference;

@Entity(value = "messages")
public class Message extends EntityModel
{
    private String message;
    private String subject; 
    private String dateString;

    @Reference(idOnly = true)
    private Consultant recipient;
    
    @Reference (idOnly = true)
    private User sender;

    public Consultant getRecipient()
    {
       return recipient;
    }

    public String getDate()
    {
        return dateString;
    }
    public void setDate(String date)
    {
        this.dateString = date;
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
    public User getUser()
    {
        return sender;
    }

}
