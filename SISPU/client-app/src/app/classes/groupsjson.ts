import {Group} from './group'

export class Groupsjson 
{
    groups: Group[]=[];

    constructor(groups: Group[]) 
    {
        this.groups = groups;
    }
}
