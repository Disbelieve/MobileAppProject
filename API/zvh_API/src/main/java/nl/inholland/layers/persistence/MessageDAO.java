/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.persistence;

import java.util.List;
import javax.inject.Inject;
import nl.inholland.layers.model.Message;
import nl.inholland.layers.model.User;
import org.mongodb.morphia.Datastore;

public class MessageDAO extends BaseDAO<Message> 
{
    private final Datastore datastore;
    
    @Inject
    public MessageDAO(Datastore ds)
    {
        super(Message.class, ds);
        this.datastore = ds;
    }    

    public List<Message> getByUser(User user){        
        List<Message> messages = createQuery().field("user").equal(user).asList();
        return messages;
    }
}
