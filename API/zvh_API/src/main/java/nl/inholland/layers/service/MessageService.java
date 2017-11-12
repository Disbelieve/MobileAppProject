/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.service;

import java.util.List;
import javax.inject.Inject;
import javax.ws.rs.NotFoundException;
import nl.inholland.layers.model.Message;
import nl.inholland.layers.persistence.MessageDAO;

public class MessageService extends BaseService {

    private final MessageDAO messageDAO;
    @Inject
    public MessageService(MessageDAO messageDAO){
        this.messageDAO = messageDAO;
    }
    
    public Message get(String messageID)
    {
        Message message = messageDAO.get(messageID);
        return message;
    }
    
    public List<Message> getAll()
    {
        List<Message> messages = null;
        try{
         messages = messageDAO.getAll();       
         
        }catch(NotFoundException e)
        {
            e.getMessage();
        }
        return messages;
    }     
        

    public void create(Message message)
    {       
        try{
        messageDAO.create(message);
        }catch(Exception e){
           
            e.getMessage();
        }
    }

}
