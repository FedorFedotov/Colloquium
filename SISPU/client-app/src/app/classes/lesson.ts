
import { Teacher} from './teacher';
import { Auditory} from './auditory';

export class Lesson  
{
    subject: string = "";
    type: number = 0;
    time_start: string = "";
    time_end: string = "";
    parity: number = 0;
    date_start: string = "";
    date_end: string = "";
    dates: number = 0;
    teachers: Teacher[]=[];
    auditories: Auditory[]=[];

    constructor() 
    {
        this.subject = "";
        this.type = 0;
        this.time_start = "";
        this.time_end= "";
        this.parity = 0;
        this.date_start = "";
        this.date_end = "";
        this.dates = 0;
        this.teachers=[];
        this.auditories=[];
    }
}
