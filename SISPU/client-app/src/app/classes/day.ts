
import { Teacher} from './teacher';
import { Auditory} from './auditory';
import { Lesson} from './lesson';

export class Day {

    weekday: number = 0;
    lessons: Lesson[]=[];

    constructor() 
    {
        this.weekday = 0;
        this.lessons = [];
    }
}

