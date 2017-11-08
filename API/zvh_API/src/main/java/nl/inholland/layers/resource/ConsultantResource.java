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

import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import nl.inholland.layers.model.Consultant;
import nl.inholland.layers.presentation.model.ConsultantPresenter;
import nl.inholland.layers.service.ConsultantService;


@Path("/consultants")
@Consumes (MediaType.APPLICATION_JSON)
@Produces (MediaType.APPLICATION_JSON)
public class ConsultantResource extends BaseResource{
    
    private final ConsultantService consultantService;
     private final ConsultantPresenter consultantPresenter;   
    @Inject
    public ConsultantResource( ConsultantService consultantService,
           ConsultantPresenter consultantPresenter 
            ){
        this.consultantService = consultantService;
        this.consultantPresenter = consultantPresenter;
    }
    
    //get all
    @GET
    public List<Consultant> getAll(){
        
        List<Consultant> consultants;
    
             consultants = consultantService.getAll();
            
            return consultantPresenter.present(consultants);         
    }          
    //get by Id
    @GET
    @Path("/{consultantId}")
    public Consultant get( @PathParam("consultantId") String consultantId){
        
        Consultant consultant = consultantService.get(consultantId);
        
        return consultantPresenter.present(consultant);
    }
    
}



