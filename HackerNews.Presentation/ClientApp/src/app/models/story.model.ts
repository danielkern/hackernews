export interface Story {
  by: string;
  descendants: number;
  id: number;
  kids: number[];
  score: number;
  time: number;
  date: Date;
  title: string;
  type: string;
  url: string;
  deleted: boolean;
  text: string;
  dead: boolean; 
  parent: number; 
  poll: string; 
  parts: number[]; 
}
