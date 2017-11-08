/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.service;

import java.util.List;
import javax.inject.Inject;
import nl.inholland.layers.model.Consultant;

import nl.inholland.layers.persistence.ConsultantDAO;


public class ConsultantService extends BaseService {

    private final ConsultantDAO consultantDAO;
    private final ResultService resultService = new ResultService();
    @Inject
    public ConsultantService(ConsultantDAO consultantDAO){
        this.consultantDAO = consultantDAO;
    }
    
        public List<Consultant> getAll()
    {
        List<Consultant> consultants = consultantDAO.getAll();
        
        if (consultants.isEmpty())
            resultService.requireResult(consultants, "geen consulenten");

        return consultants;
    }

    public Consultant get(String consultantId) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    

    
}
