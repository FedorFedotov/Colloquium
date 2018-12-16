export class Groupchat {

  group_name: string = "";
  group_department: string ="";
  group_employment: string ="";
  group_tasks: string[] = [];
  group_answers: string[] = [];
  group_advice: string[] = [];
  group_recs: string[] = [];

  constructor() 
  {   this.group_name = "";
      this.group_department ="";
      this.group_employment ="";
      this.group_tasks = [];
      this.group_advice = [];
      this.group_answers = [];
      this.group_recs = [];
  }
}

