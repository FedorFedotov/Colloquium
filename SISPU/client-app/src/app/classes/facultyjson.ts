import {Group} from './group'

export class Facultyjson {
    faculty_name: string = "";
    faculty_id: number = 0;
    groups: Group[]=[];
  
    constructor()
    {
      this.faculty_name= "";
      this.faculty_id = 0;
      this.groups = [];
    }
}
