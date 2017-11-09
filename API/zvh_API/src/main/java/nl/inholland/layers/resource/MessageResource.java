/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.resource;
import java.util.List;
import javax.inject.Inject;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import nl.inholland.layers.model.Message;
import nl.inholland.layers.presentation.model.MessagePresenter;
import nl.inholland.layers.service.MessageService;

@Path("/messages")
@Consumes (MediaType.APPLICATION_JSON)
@Produces (MediaType.APPLICATION_JSON)
public class MessageResource extends BaseResource{
    
    private final MessageService messageService;
    private final MessagePresenter messagePresenter;
    
    @Inject
    public MessageResource( MessageService messageService,
            MessagePresenter messagePresenter){
        this.messageService = messageService;
        this.messagePresenter = messagePresenter;
    }

    @GET
    public List<Message> getAll(){
        
        List<Message> messages = messageService.getAll();
        
        return messagePresenter.present(messages);
      
    }
    
    @POST
    public void create(Message message)
    {
       messageService.create(message);

    }
    //get by Id
    @GET
    @Path("/{messageId}")
    public Message get( @PathParam("messageId") String messageId){
        Message message = messageService.get(messageId);
        
        return messagePresenter.present(message);
    }


}
