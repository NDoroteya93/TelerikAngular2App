import { Component, OnInit } from '@angular/core';

@Component({
    selector: "header",
    templateUrl: './header.component.html',
    styleUrls: [`
.header-cont {
    width:100%;
    position:fixed;
    top:0px;
    -webkit-box-shadow:0px 1px 30px 0px #000000;
 -moz-box-shadow:0px 1px 30px 0px #000000;
 box-shadow:0px 1px 30px 0px #000000;
    background:#F0F0F0;
}
.content {
    width:960px;
    background: #F0F0F0;
    border: 1px solid #CCC;
    height: 2000px;
    margin: 70px auto;
}
h1{
    width:250px;
    float:left;
    padding-left:50px;
}
ul{
    list-style:none;
}
ul li {
    float:left;
    padding-right:10px;
}
#dvMenu{
    float:right;
        padding-right: 300px;
    padding-top: 10px;
}
 a{
                    font-size: 20pt;
                 padding-bottom: 5px;
                  color: black;
                  text-decoration: none;
            }
`]
})

export class HeaderComponent {

}