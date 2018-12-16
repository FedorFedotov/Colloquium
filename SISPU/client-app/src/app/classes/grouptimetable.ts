
import { Teacher} from './teacher';
import { Auditory} from './auditory';
import { Lesson} from './lesson';
import { Day} from './day';

export class Grouptimetable {

    group_name: string = "";
    days: Day[]=[];

    constructor() 
    {   this.group_name = "";
        this.days = [];
    }
}
