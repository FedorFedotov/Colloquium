
import { Teacher} from './teacher';
import { Auditory} from './auditory';
import { Lesson} from './lesson';
import { Day} from './day';

export class Grouptimetable {

    group_name: string = "";
    group_department: string ="";
    group_employment: string ="";
    group_tasks: number = 0;
    group_tasks2: string[] = [];
    group_answers: string[] = [];
    group_advice: number = 0;
    group_advice2: string[] = [];
    group_recs: string[] = [];
  
    constructor() 
    {   this.group_name = "";
        this.group_department ="";
        this.group_employment ="";
        this.group_tasks = 0;
        this.group_tasks2 = [];
        this.group_advice = 0;
        this.group_advice2 = [];
        this.group_answers = [];
        this.group_recs = [];
    }
}
