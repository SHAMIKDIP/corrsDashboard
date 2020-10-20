import {Component, Injectable} from '@angular/core'
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap' 
@Injectable({
    providedIn: 'root'
})
@Component({ 
    selector: 'common-modal', 
    templateUrl: './Modal.html'
}) 
export class CommonModal { 
    closeResult = ''

    constructor(private modalService: NgbModal) {} 

    open(content:any) { 
        this.modalService.open(content, 
            {ariaLabelledBy: 'modal-basic-title'}).result.then((result)	=> { 
            this.closeResult = `Closed with: ${result}`
        }, (reason) => { 
        this.closeResult = 
            `Dismissed ${this.getDismissReason(reason)}`
        }); 
    } 

    private getDismissReason(reason: any): string { 
        if (reason === ModalDismissReasons.ESC) { 
            return 'by pressing ESC'
        } else if (reason === ModalDismissReasons.BACKDROP_CLICK) { 
                return 'by clicking on a backdrop'
        } else { 
            return `with: ${reason}`
        } 
    } 
} 
