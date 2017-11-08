/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.service;

import java.util.List;
import javax.inject.Inject;
import nl.inholland.layers.model.Message;
import nl.inholland.layers.persistence.MessageDAO;

public class MessageService extends BaseService {

    private final MessageDAO messageDAO;
    private final ResultService resultService = new ResultService();
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
        List<Message> messages = messageDAO.getAll();
        
        if (messages.isEmpty())
            resultService.requireResult(messages, "Geen berichten gevonden");

        return messages;
    }     
        

    public void create(Message message)
    {
        messageDAO.create(message);
    }

}
