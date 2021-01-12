var siteUrl=location.host+'/';
if(siteUrl.toUpperCase().indexOf('LOCALHOST:')>=0)
    siteUrl=siteUrl +'tingtongindia/';
if (location.protocol == 'http:')
{
   siteUrl = 'http://' + siteUrl;
}
else
{
   siteUrl = 'https://' + siteUrl;
}
var siteUrlNew = location.host+'/';
if(siteUrlNew.toUpperCase().indexOf('LOCALHOST:')>=0)
    siteUrlNew=siteUrlNew +'tingtongindia/';
 else if(siteUrlNew.toUpperCase().indexOf('WWW')>=1)
    {
        var index = siteUrlNew.indexOf('.tingtongindia');
        var str = siteUrlNew.substring(0,index);
         siteUrlNew = siteUrlNew.replace(str,'www');
    }
  if (location.protocol == 'http:')
{
   siteUrlNew = 'http://'+siteUrlNew;  
}
else
{
   siteUrlNew = 'https://'+siteUrlNew;  
}
var xmlhttp;
var total=0;
var m=0;
var chkSpeed=1;
var searchStr="",prevSearchStr="-Xms-a";
var param;
var url;
function shwRst(str, e) {   
    var charCode = e.which || e.keyCode;
    if(charCode!=27)// for escape
     {     
         if(total>0)
            { 
                if (charCode == 40)
                {
                    total=parseInt(total);
                    for(a=1; a<total+1; a++)
                    {
                        document.getElementById(a).style.backgroundColor='#FFFFFF'
                        document.getElementById(a).style.color='#000000'                        
                    }  
                    if(m<total)
                    {
                        m=m+1;
                    }
                    else
                    {
                        m=0;
                    } 
                    if(document.getElementById(m))
                    {
                        document.getElementById(m).style.backgroundColor='#3366cc'
                        document.getElementById(m).style.color='#FFFFFF' 
                        document.getElementById("txt_srctxt").value=(document.getElementById(m).innerHTML).replace(/<\/?[^>]+(>|$)/g, "");
                    }
                    return false;   
                }      
                else if (charCode == 38)
                {
                    if(m>1)
                    {m=m-1;}
                    for(a=1; a<total+1; a++)
                    {
                        document.getElementById(a).style.backgroundColor='#FFF'
                        document.getElementById(a).style.color='#000'                       
                    }   
                    if(document.getElementById(m))
                    {
                        document.getElementById(m).style.backgroundColor='#3366cc'
                        document.getElementById(m).style.color='white'          
                        document.getElementById("txt_srctxt").value=(document.getElementById(m).innerHTML).replace(/<\/?[^>]+(>|$)/g, "");
                    }
                    return false;
                }
                else
                {
                    m=0;
                }
            }
            if (str.length==0)
            {
                document.getElementById("livesearch").innerHTML="";
                document.getElementById("livesearch").style.display='none';
                return;
            }
            xmlhttp=GetXmlHttpObject()
            if (xmlhttp==null)
            {
                alert ("Browser does not support HTTP Request");
                return;
            }
            if(document.getElementById("txtHdnCityId").value!="0")
            {
                searchStr=str; 
                if(chkSpeed==1) //&& searchStr.indexOf(prevSearchStr)!=0)
                {
                    chkSpeed=0;
                  //  var Country=document.getElementById("txtHdnCountryId").value;
                    var Country=1;
                    var city=document.getElementById("txtHdnCityId").value;
                    var area=document.getElementById("txtHdnAreaId").value;                  
                        str=removeall(str);
                        param='&txt='+encodeURIComponent(str)+'&city='+city+'&area='+area+'&Country='+Country;
                        url= siteUrl +"js/SearchAutoSuggest.ashx?"+param;                                                          
                        xmlhttp.onreadystatechange=stateChg;
                        xmlhttp.open("GET",url,true);
                        xmlhttp.send(null);
                }
                else
                    chkSpeed=0;
            }
            else
            {
                alert("Please Select City to Search in.");
                return false;
            }
      }
      else
      {
          document.getElementById("livesearch").style.display='none';
      }
}
function stateChg()
{
    if(xmlhttp.readyState==4)
    {
        var txt=xmlhttp.responseText;    
        var index=txt.indexOf('~!')
        total=txt.substring(index+2)
        txt=txt.substring(0,index)
        if(txt.length!=85)
        { 
            document.getElementById("livesearch").style.display='block';
            document.getElementById("livesearch").innerHTML=txt;            
        }
        else
        {
            document.getElementById("livesearch").style.display='none'; 
            prevSearchStr=searchStr;
        }
        chkSpeed=1; 
    }
    else if(xmlhttp.readyState==0)
        chkSpeed=1; 
}
function GetXmlHttpObject()
{
    if (window.XMLHttpRequest)
    {
        // code for IE7+, Firefox, Chrome, Opera, Safari
        return new XMLHttpRequest();
    }
    if (window.ActiveXObject)
    {
        // code for IE6, IE5
        return new ActiveXObject("Microsoft.XMLHTTP");
    }
    return null;
}
function TdMouseOver(obj)
{
    obj.style.backgroundColor='#3366cc' 
    obj.style.color='white' 
    if(document.getElementById('r'+obj.id))
    {
        document.getElementById('r'+obj.id).style.backgroundColor='#3366cc';
        document.getElementById('r'+obj.id).style.color='white' ;
    }
}
function TdMouseOut(obj)
{
    obj.style.backgroundColor='#FFF' 
    obj.style.color='#000'
    if(document.getElementById('r'+obj.id))
    {
        document.getElementById('r'+obj.id).style.backgroundColor='#FFF' 
        document.getElementById('r'+obj.id).style.color='green' 
    }
}
//====================================Url Gen===================================
function GetTxt(phrase,city_id, area_id)
{
   var text='';
    if(document.getElementById('CityDiv')!=undefined && document.getElementById('CityDiv').style.display=='none')
    {
        document.getElementById("txt_srctxt").value= phrase;
        var s=document.getElementById("txt_srctxt").value;
        window.location.href=siteUrlNew+'India/'+s+'-0A0P1/';//A0N0/';
        return false;
    }
    else if(document.getElementById("txtHdnCityId").value!="0")
    {
      document.getElementById("txt_srctxt").value= phrase;
      document.getElementById("livesearch").style.display='none'; 
      var c=document.getElementById("txtHdnCityId").value;
      var a=document.getElementById("txtHdnAreaId").value;
      var s=document.getElementById("txt_srctxt").value;
      var Str_City=document.getElementById("txtActCity").value.replace(',','');
      Str_City=Str_City.replace(/ /g,'-')
      if(c!=0){city_id=c;}if(a!=0){area_id=a;}
      s=s.replace(/ /g,'-') //means replace all spaces within users input query 
       //s=s.replace(/'/g,'')
      s=s.replace(/&/g,'(and)')
      s = s.replace('+', 'Pls'); s = s.replace('+', 'Pls'); s = s.replace('+', 'Pls'); s = s.replace('(', '-'); s = s.replace(')', '-'); s = s.replace('[', '-'); s = s.replace(']', '-').replace('  ','-');
      s = ReplaceAll(s, '(', '-');
      s = ReplaceAll(s, ')', '-');
      if(a=="0")
      {
              window.location.href=siteUrlNew+Str_City+'/'+s+'-C' + city_id+'A' + area_id+'P1A0/'; 
      }
      else
      {
              window.location.href=siteUrlNew+Str_City+'/'+s+'-C' + city_id+'A' + area_id+'P1A0/'; 
      }
      return false;
    }
    else
    {
        alert("Please Select City to Search in.");
        return false;
    }
}
function GoToNamingSearch(e)
{
  var charCode = e.which || e.keyCode;
  if (charCode == 13 || charCode==1 || charCode==0)
  {
        if(document.getElementById('CityDiv')!=undefined && document.getElementById('CityDiv').style.display=='none')
        { 
            if(document.getElementById("txt_srctxt").value.trim()=="" || document.getElementById("txt_srctxt").value.trim()=='Search by Business Name, Product Name or Service')
            {
                return false;
            }
            else
            {          
                  var strng=document.getElementById("txt_srctxt").value;
                  var s=removeall(strng);
                 if(s!=''  && document.getElementById("txt_srctxt").value.toUpperCase()!=('Search by Business Name, Product Name or Service').toUpperCase())
                    {
                       if(s.length<2 && charCode==1)
                       {
                          alert("Please enter atleast 2 characters.");
                          return false;
                       }
                       else if(s.length>1)
                        {                          
                            window.location.href=siteUrlNew+'India/'+s+'-0A0P1/';//A0N0/';
                            return false;
                        }
                    }
                else
                    {
                        document.getElementById("txt_srctxt").value.trim()=="";
                        return false;
                    }
            }
        }
        else if(document.getElementById("txt_srctxt").value.trim()!="" && document.getElementById("txt_srctxt").value.trim()!='Search by Business Name, Product Name or Service')
          {
               if(document.getElementById("txtHdnCityId").value!="0")
               {
                var strLen=document.getElementById("txt_srctxt").value.trim()
                if(strLen.length<2 && charCode==1)
                    {
                      alert("Please enter atleast 2 characters.");
                      return false;
                    }
                else if(strLen.length<2)
                    {
                      return false;
                    }
                else
                    {
                      return GoPage();
                    }
               }
                else
                    {
                        alert("Please Select City to Search in.");
                        document.getElementById("txtActCity").focus();
                        return false;
                    }
          }          
    }
}
function GoPage()
{  
        var city_id=document.getElementById("txtHdnCityId").value;
        var area_id=document.getElementById("txtHdnAreaId").value;
        var strng=document.getElementById("txt_srctxt").value;
         var s=removeall(strng);
        var Str_City=document.getElementById("txtActCity").value.replace(',','');
        Str_City=Str_City.replace(/ /g,'-');
        Str_City=Str_City.replace(' ','-');
        s = s.replace('  ',' ').replace('  ',' ').replace('  ',' ').replace('  ',' ');
        s =   s.replace(/\s+/g, '-');          
        if(s!='' &&  document.getElementById("txt_srctxt").value.toUpperCase()!=('Search by Business Name, Product Name or Service').toUpperCase())
        {
         s=s.replace(/\+/g,'pls');
             if(area_id=="0")
             {                    
               window.location.href=siteUrlNew+Str_City+'/'+s+'-C' + city_id +'A' + area_id+'P1A0/';
             }
             else
             {            
                  window.location.href=siteUrlNew+Str_City+'/'+s+'-C' + city_id + 'A' + area_id+'P1A0/'; 
             }
             return false;
        }
        else
        {           
            return false;
        }
    }
/* Function for Replcing All char instance in Specified string create bt Alok 23-Feb-11 */
    function ReplaceAll(sourecestring, stringtofind, stringtoreplace) 
    {
        var temp = sourecestring;
        var index = temp.toString().indexOf(stringtofind);
        while (index != -1) 
        {
            temp = temp.replace(stringtofind, stringtoreplace);
            index = temp.indexOf(stringtofind);
        }
        return temp;
    }
    /* Function for Replcing All char instance in Specified string create bt sanjeev 31-may-12 */
 function removeall(strtorem) {
        var str = strtorem;
        var n = str.split("");
           str='';
        for (var i = 0; i < n.length; i++) {
            if (n[i] != '~' &  n[i] != '`' &  n[i] != '@' & n[i] != '!' & n[i] != "'" & n[i] != '#'  & n[i] != '$'  & n[i] != '%' & n[i] != '^' & n[i] != '&' & n[i] != '^' & n[i] != '*' & n[i] != '(' & n[i] != ')' & n[i] != '_' & n[i] != '=' & n[i] != '{' & n[i] != '}' & n[i] != '['& n[i] != ']' & n[i] != '|' & n[i] != '"' & n[i] != ';' & n[i] != ':' & n[i] != '?' & n[i] != '/'  & n[i] != '>' & n[i] != '<' & n[i] != '.' & n[i] != ',' ) {
                str+= n[i];
            }
        }       
        return str;
    }
//===========================================End Url Gen=================================================
//=======================================
function HideList()
{ 
    var e = window.event;
    if (window.captureEvents) 
    {
        window.captureEvents(Event.CLICK);
        window.onclick=getControlId;
    }
      document.onclick = getControlId;
}
function getControlId(e)
 {
     var el=(typeof event!=='undefined')? event.srcElement : e.target
     var targetId=el.id;        
     if(targetId!='txtActCity' && targetId!='txtArea' && targetId!='txtCity' && targetId!='txtTempArea' && targetId!= 'divAllCountry' &&  targetId!= 'ArrowImg' )
     {
        document.getElementById("divcity").style.display='none';
        document.getElementById("divArea").style.display='none';      
         //document.getElementById("ViewCountry").style.display='none';
     }
     document.getElementById("livesearch").style.display='none'
}
//==========================================Load Home=================================
var wit=0;
function Pass(x)
    {
        var left = (screen.width/2)-(200);
       window.open("UserAccount/popup.aspx?ab=" + x ,'','scrollbars=yes,width=517,height=600,left='+left);
       return false;
    }
String.prototype.trim = function () {return this.replace(/^\s*/, "").replace(/\s*$/, "");}
document.getElementById('txtCity').value='Type City';
document.getElementById('txtTempArea').value='Type Area';
if(document.getElementById('txt_srctxt').value=='')
{
    document.getElementById('txt_srctxt').value='Search by Business Name, Product Name or Service';
    setBackText(document.getElementById('txt_srctxt'));
}
function setBackText(obj)
{
   obj.style.fontStyle='normal';obj.style.color='gray';
}
setBackText(document.getElementById('txtCity'));setBackText(document.getElementById('txtTempArea'));
function setFocus(obj, txt)
{
    if(obj.value.trim().toUpperCase()==txt.toUpperCase())
        obj.value='';
    obj.style.fontStyle='Normal';obj.style.color='black';    
} 
function hideArea()
{
    if (document.getElementById("divArea").style.display=='inline')
    {
       document.getElementById("divArea").style.display='none';
    }   
}
function outFocus(obj, txt)
{
    if(obj.value.trim()=='')
    {
        obj.value=txt;
        setBackText(obj);
    }
}
    function ajaxClient()
    {
        var xmlhttp= null;
        if (window.XMLHttpRequest)
          {// code for IE7+, Firefox, Chrome, Opera, Safari
          xmlhttp=new XMLHttpRequest();
          }
        else
          {// code for IE6, IE5
          xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
          }
          return xmlhttp;
    }
    var areas=null;var existingCityId=0;var cities=null; var existingCountryId=0;
    function addCity(cityId,city)
    {
         var div= document.getElementById("divAllCities");
         div.scrollTop=0;
        document.getElementById('txtHdnCityId').value=cityId;document.getElementById('txtActCity').value=city;document.getElementById('divcity').style.display='none';
        // document.getElementById('divATM').style.display='block';
      //  document.getElementById('divATM').innerHTML = "<a style=\"color:red;\" href=\"https://www.tingtongindia.com/" + city.replace(/ /g,'-') + "/ATM-C" + cityId + "/\"> Find an ATM / Bank near you. </a>";
        if(existingCityId!=cityId){AddAjaxAreas(cityId,0);existingCityId=cityId;} 
         m=0; s=0;
    }
//--------------------------------------------------- code by sumit tyagi for arrow keys ----------------------------------------------   
    var m=0; var start=0;var setScroll=0; var s=0;// variable for city drop down
    var n=0; var astart=0;var setAreaScroll=0;var firsttime=0 // variable for area drop down
     function closeCity()
        {
            document.getElementById("divAllCities").scrollTop=0;
            document.getElementById('divcity').style.display='none';
             m=0;s=0;  
        }
     function closeArea()
        {
            document.getElementById("divAllArea").scrollTop=0;
            document.getElementById('divArea').style.display='none';
            n=0;firsttime=0;
        }
function HideList1()
    {     
    var e = window.event;
    if (window.captureEvents) 
            {
            window.captureEvents(Event.CLICK);
          window.onclick=getControlId;
          }
      document.onclick = getControlId2;
    }
function getControlId2(e)
 {
     var el=(typeof event!=='undefined')? event.srcElement : e.target
     var targetId=el.id;            
     if(targetId!='txtActCity' && targetId!='txtArea' && targetId!='txtCity' && targetId!='txtTempArea' &&  targetId!= 'ArrowImg')
     {
        document.getElementById("divAllCities").scrollTop=0;
        document.getElementById("divcity").style.display='none';
        document.getElementById("divAllArea").scrollTop=0;
        document.getElementById("divArea").style.display='none';     
        m=0;s=0;  n=0;firsttime=0;
     }
     document.getElementById("livesearch").style.display='none' 
}
 function getElementsByName_iefix(tag, name) 
 {
     var elem = document.getElementsByTagName(tag);
     var arr = new Array();
     for(i = 0,iarr = 0; i < elem.length; i++) 
     {
          att = elem[i].getAttribute("name");
          if(att == name) 
          {
               arr[iarr] = elem[i];
               iarr++;
          }
     }
     return arr;
}
function keyUpDownCity(e)
{
    var charcode=e.which || e.keyCode;    
    var allcity=getElementsByName_iefix('span','allCity');
    if(charcode!=40 && charcode!=13 && charcode!=37 && charcode!=38 && charcode!=39 )
        {
          for(k=0;k<5;k++)
            {
                m=allcity[k].id;  
                break;
            }
            try
            {
               m=m.substr(1);                
            }
            catch(e)
            {
            }
            start=m;
            s=0;           
        }       
         if(m>14)
         {
            var div= document.getElementById("divAllCities");            
            setScroll=1;
            div.scrollTop=m*8+20;
         }
         else if(m<=14 && setScroll==1 && m>1)
         {
            var div= document.getElementById("divAllCities");
            if(((m*8)-20)>0)
            div.scrollTop=(m*8-20);
            else
            div.scrollTop=0;
         }        
            if(charcode==40)// for Down arrow
            {         
                 for(i=0;i<cities.length;i++)
                 {
                   if(document.getElementById('c'+i))
                   document.getElementById('c'+i).style.backgroundColor='#FFFFFF';
                 }
              if(m==start && s==0)
              {                       
                document.getElementById('c'+m).style.backgroundColor='#D0E3FF';           
                s=1;  
              }
              else 
              {
                    if(s==1)
                    {
                       m=parseInt(m)+parseInt(2);                                
                          if(document.getElementById('c'+m))
                          {
                             document.getElementById('c'+m).style.backgroundColor='#D0E3FF';                             
                          }
                          else
                          {
                              m=parseInt(m)-parseInt(1);
                              document.getElementById('c'+m).style.backgroundColor='#D0E3FF';                            
                          }
                    }
                    else
                    {
                         m=parseInt(m)+parseInt(2);
                         if(document.getElementById('c'+m))
                          {
                             document.getElementById('c'+m).style.backgroundColor='#D0E3FF';                            
                          }
                          else
                          {
                              m=parseInt(m)-parseInt(2);
                              document.getElementById('c'+m).style.backgroundColor='#D0E3FF';                            
                          }  
                    }
              }
            }
             if(charcode==39)// for Right arrow
            {
                 for(i=0;i<cities.length;i++)
                 {
                   if(document.getElementById('c'+i))
                   document.getElementById('c'+i).style.backgroundColor='#FFFFFF';
                 }
                   if(m==parseInt(start)+parseInt(1))
                    {
                         document.getElementById('c'+m).style.backgroundColor='#D0E3FF';                       
                    }
                    else
                    {
                         m=parseInt(m)+parseInt(1);
                        if(document.getElementById('c'+m))
                         {
                            document.getElementById('c'+m).style.backgroundColor='#D0E3FF';
                         }
                         else
                         {
                             m=parseInt(m)-parseInt(1);
                             document.getElementById('c'+m).style.backgroundColor='#D0E3FF';
                         }                         
                    }
            }    
            if(charcode==37)// for Left arrow
            {
                for(i=0;i<cities.length;i++)
                 {
                   if(document.getElementById('c'+i))
                   document.getElementById('c'+i).style.backgroundColor='#FFFFFF';
                 }                 
                 if(m==start)
                 {
                        m=start;
                        document.getElementById('c'+m).style.backgroundColor='#D0E3FF';
                 }
                 else
                 { 
                     m=parseInt(m)-parseInt(1);
                     document.getElementById('c'+m).style.backgroundColor='#D0E3FF';
                 }
            }
            if(charcode==38)// for Up arrow
            {
                 for(i=0;i<cities.length;i++)
                 {
                   if(document.getElementById('c'+i))
                   document.getElementById('c'+i).style.backgroundColor='#FFFFFF';                  
                 }                 
                   m=parseInt(m)-parseInt(2);
                     if(m<1)
                        {m=0;}
                   document.getElementById('c'+m).style.backgroundColor='#D0E3FF';
           }
             if(charcode==13)
             {
                  document.getElementById('c'+m).onclick();
             }
}
function keyUpDownArea(e)
{
    var charcode=e.which || e.keyCode;
    var allarea=getElementsByName_iefix('span','allAreas');
        if(charcode!=40 && charcode!=13 && charcode!=37 && charcode!=38 && charcode!=39 )
        {
         for(k=0;k<allarea.length;k++)
            {              
                 n=allarea[k].id;  
                 break;
            } 
            try
            {
             n=n.substr(1);
            }
            catch(e)
            {
            }
            firsttime=0;
            astart=n;
        }       
      if(n>14)
         {
            var div= document.getElementById("divAllArea");
            setAreaScroll=1;
            div.scrollTop=n*10+20;
         }
         else if(n<=14 && setAreaScroll==1 && n>1)
         {
            var div= document.getElementById("divAllArea");
            if(((n*8)-20)>0)
            div.scrollTop=(n*8-20);
            else
            div.scrollTop=0;
         }
            if(charcode==40)// for Down arrow
            {         
                 for(i=0;i<areas.length;i++)
                 {
                   if(document.getElementById('a'+i))
                   document.getElementById('a'+i).style.backgroundColor='#FFFFFF';
                 }
              if(n==astart && firsttime==0)
              {
                document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                 firsttime=1
              }
              else if(firsttime==1)
              {
                    if(n==parseInt(astart)+parseInt(1))
                    {
                         n=parseInt(n)+parseInt(2);
                          if(document.getElementById('a'+n))
                          {
                             document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                          }
                          else
                          {
                              n=parseInt(n)-parseInt(1);
                              document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                          }
                   }
                    else
                    {
                         n=parseInt(n)+parseInt(2);
                        if(document.getElementById('a'+n))
                          {
                             document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                          }
                          else
                          {
                              n=parseInt(n)-parseInt(2);
                              document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                          }  
                    }
              }
            }
             if(charcode==39)// for Right arrow
            {
                 for(i=0;i<areas.length;i++)
                 {
                   if(document.getElementById('a'+i))
                   document.getElementById('a'+i).style.backgroundColor='#FFFFFF';
                 }
                   if(n==parseInt(astart)+parseInt(1))
                    {
                         document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                    }
                    else
                    {
                         n=parseInt(n)+parseInt(1);
                         if(document.getElementById('a'+n))
                         {
                             document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                         }
                         else
                         {
                            n=parseInt(n)-parseInt(1);
                            document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                         }   
                    }         
          }    
          if(charcode==37)// for Left arrow
            {
               for(i=0;i<areas.length;i++)
                 {
                   if(document.getElementById('a'+i))
                   document.getElementById('a'+i).style.backgroundColor='#FFFFFF';
                 }
                 if(n==astart)
                 {
                     n=astart
                     document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                 }
                 else
                 {
                     n=parseInt(n)-parseInt(1);
                     document.getElementById('a'+n).style.backgroundColor='#D0E3FF';
                 }
            }
            if(charcode==38)// for Up arrow
            {
                 for(i=0;i<areas.length;i++)
                 {
                   if(document.getElementById('a'+i))
                   document.getElementById('a'+i).style.backgroundColor='#FFFFFF';
                 }
                 n=parseInt(n)-parseInt(2);
                 if(n<0)
                 {n=0;}                     
                    document.getElementById('a'+n).style.backgroundColor='#D0E3FF';             
            }
             if(charcode==13)
             {
                document.getElementById('a'+n).onclick();
             }
}    
       function showSeletedCountry(e)
        {                
               var Chk = 0; 
               if(location.host.toUpperCase().indexOf('WWW') == 0 )
               { Chk = 1 ;} else if(location.host.toUpperCase().indexOf('stg') == 0){ Chk = 1 ; } 
               else if(location.host.toUpperCase().indexOf('LOCALHOST') ==  0 ){ Chk = 1 ; } else { Chk = 2 ;}              
                var strHtml="";
                 for(i=0;i<Countries.length;i++)
                    {                   
                     if( Chk == 1)
                     {                                     
                          if(Countries[i][1]=="USA")
                          {
                             strHtml +="<div class=\"font row\" onclick =\"Redirect('"+ Chk +"')\">";                             
                          } 
                          else
                          {
                             strHtml +="<div  onclick=\'addCountries("+Countries[i][0]+",\""+Countries[i][1]+"\")\' class=\"font row\">";                             
                          }
                          strHtml +="<span style=\"float:left;\"><img src=\""+ siteUrl +"images/" + Countries[i][1] + ".png\" /></span>";                                           
                          strHtml +="<span style=\"float:left; margin-left:8px;\" name='allCountries' id='S"+i+"'>"+Countries[i][1]+"</span></a>";  
                      }
                      else
                      {
                         if(Countries[i][1]=="India")
                          {
                             strHtml +="<div class=\"font row\" onclick =\"Redirect('"+ Chk +"')\">";                            
                          } 
                          else
                          {
                             strHtml +="<div  onclick=\'addCountries("+Countries[i][0]+",\""+Countries[i][1]+"\")\' class=\"font row\">";                            
                          }
                          strHtml +="<span style=\"float:left;\"><img src=\""+ siteUrl +"images/" + Countries[i][1] + ".png\" /></span>";                                           
                          strHtml +="<span style=\"float:left; margin-left:8px;\" name='allCountries' id='S"+i+"'>"+Countries[i][1]+"</span></a>";  
                      }                                 
                          strHtml +="</div>";                      
                    }
                  // document.getElementById('ViewCountry').innerHTML=strHtml;   
        }
    function divGetAllCountries()
        {      
         document.getElementById("divcity").style.display='none';
         document.getElementById("divArea").style.display='none';
         document.getElementById("livesearch").style.display='none';
         //document.getElementById("ViewCountry").style.display='block';         
        }
        function addCountries(CountryId,CountryName)
            {           
         var div= document.getElementById("ViewCountry");               
         div.scrollTop=0;
         document.getElementById('txtHdnCountryId').value=CountryId;
        // document.getElementById('txtCountry').innerHTML=CountryName;
         document.getElementById('ViewCountry').style.display='none';                   
          if(CountryId == 1){  document.getElementById("RdiButton").style.display='inline'; } else { document.getElementById("RdiButton").style.display='none';}        
          n=0;firsttime=0;
          if(existingCountryId!=CountryId)
              {
               AddAjaxCity(CountryId,0);
               existingCountryId=CountryId;
              }  
           m=0; s=0;                       
          }
     function AddAjaxCity(CountryId,note) {  
       XmlHttp = GetXmlHttpObject();
       XmlHttp.open("GET",siteUrl+"Handler/ajax.ashx?CountryId="+CountryId+"",true);   
       XmlHttp.send(null);
      XmlHttp.onreadystatechange=function(){    
     if (XmlHttp.readyState==4 && XmlHttp.status==200)
          {         
              var xmlDoc = XmlHttp.responseXML;                                
               cities= xmlDoc.getElementsByTagName("City"); 
            if(note==0)
                {           
               if(document.getElementById('imgload'))
                   document.getElementById('imgload').style.display='none';     
                    document.getElementById('txtHdnCityId').value='0';
                    document.getElementById('txtActCity').value='Select City'; 
                    document.getElementById('txtHdnAreaId').value='0';
                    document.getElementById('txtArea').value='Any Area';                          
                }
                else
                {
                        if(document.getElementById('txtHdnCityId').value!='0')
                        {
                                if(cities!=null && cities.length>0)
                                {
                                        for(j=0;j<cities.length;j++)
                                        {
                                                if(cities[j].getAttribute("id")==document.getElementById('txtHdnCityId').value)
                                                {
                                                    document.getElementById('txtActCity').value=cities[j].getAttribute("name");   
                                                  //  document.getElementById('divATM').style.display='block'; 
                                                 //   document.getElementById('divATM').innerHTML = "<a style=\"color:red;\" href=\"https://www.tingtongindia.com/" + city.replace(/ /g,'-') + "/ATM-C" + cityId + "/\"> Find an ATM / Bank near you. </a>";                                               
                                                    break;
                                                }
                                        }
                                }
                        }
                }            
            showSeletedCity(this.event);                        
          }
       }
    }
    function showSeletedCity(e)
    {  
        var value = document.getElementById('txtCity').value.trim();     
            var strHtml="";
            var note=0; 
            var charcodee;
                  if(e)charcodee=e.which || e.keyCode;
                  if (charcodee != 40 && charcodee != 13 && charcodee != 37 && charcodee != 38 && charcodee != 39) {
                    if(charcodee==27)// for Escape
                    {
                       document.getElementById("divAllCities").scrollTop=0;
                       document.getElementById('divcity').style.display='none'
                       m=0;s=0; 
                    }
                    else {                                        
                        if (cities != null) {
                              for(i=0;i<cities.length;i++)
                                    {
                                        if(value.toUpperCase()!='TYPE CITY' && cities[i].getAttribute("name").length>=value.length && (cities[i].getAttribute("name").substring(0,value.length).toUpperCase()==value.toUpperCase()))
                                        {                                           
                                            strHtml += "<span name='allCity' id='c" + i + "' onclick=\'addCity(" + cities[i].getAttribute("id") + ",\"" + cities[i].getAttribute("name") + "\")\'>" + cities[i].getAttribute("name") + "</span>";
                                            note=1;
                                        }
                                        else if(value=='' || value.toUpperCase()=='TYPE CITY')
                                        {
                                            strHtml +="<span name='allCity' id='c" + i + "' onclick=\'addCity(" + cities[i].getAttribute("id") + ",\"" + cities[i].getAttribute("name") + "\")\'>" + cities[i].getAttribute("name") + "</span>";
                                            note=1;
                                        }
                                    }
                            }   
                           if(note==0)
                    strHtml="Sorry no matching city found";
                document.getElementById('divAllCities').innerHTML=strHtml;                                   
                if(e)keyUpDownCity(e,'s');
            }
        }
         else
            keyUpDownCity(e,'s');                         
    }
    function divArea()
    {
        if(document.getElementById('txtHdnCityId').value!="0")
        {
            if(areas==null || areas.length==0)
             AddAjaxAreas(document.getElementById('txtHdnCityId').value,0);
            document.getElementById('txtTempArea').value='Type Area';setBackText(document.getElementById('txtTempArea'));document.getElementById('divArea').style.display='inline';document.getElementById('divcity').style.display='none';showSeletedArea(this.event);
            document.getElementById('txtTempArea').focus();
        }
        else
            alert("Please select any city");
    }
    function addArea(areaId,area)
    {
     document.getElementById("divAllArea").scrollTop=0;
     document.getElementById('txtHdnAreaId').value=areaId;document.getElementById('txtArea').value=area;
     document.getElementById('divArea').style.display='none'; 
     n=0;firsttime=0;
     }
    function AddAjaxAreas(cityId,note)
    {
        var xmlRequest= GetXmlHttpObject();
        document.getElementById('loading').style.display='inline';
        if(document.getElementById('imgload'))
        document.getElementById('imgload').style.display='inline';
        xmlRequest.onreadystatechange=function(){
          if (xmlRequest.readyState==4 && xmlRequest.status==200)
          {var xmlDoc= xmlRequest.responseXML;
          areas=xmlDoc.getElementsByTagName("area");
            if(note==0)
            {
                document.getElementById('txtHdnAreaId').value='0';document.getElementById('txtArea').value='Any Area';
            }
            else
            {
                if(document.getElementById('txtHdnAreaId').value!='0')
                {
                    if(areas!=null && areas.length>0)
                    {
                        for(j=0;j<areas.length;j++)
                        {
                            if(areas[j].getAttribute("id")==document.getElementById('txtHdnAreaId').value)
                            {
                                document.getElementById('txtArea').value=areas[j].getAttribute("name");
                                break;
                            }
                        }
                    }
                }
            }
            showSeletedArea(this.event);
            document.getElementById('loading').style.display='none';
            if(document.getElementById('imgload'))
            document.getElementById('imgload').style.display='none';
          }
        }
        xmlRequest.open("GET",siteUrl+"Handler/ajax.ashx?cityId="+cityId+"",true);
        xmlRequest.send(null);
    }
    function reverse(s){
    return s.split("").reverse().join("");
}
     function showSeletedArea(e)
    {  
            var value = document.getElementById('txtTempArea').value.trim();                  
            var strHtml="";var note=0;
             var charcodee=0;
            if(e)
                charcodee=e.which || e.keyCode; 
          if(charcodee!=40 && charcodee!=13 && charcodee!=37 && charcodee!=38 && charcodee!=39 )
            {
                 if(charcodee==27)
                {
                     document.getElementById("divAllArea").scrollTop=0;
                     document.getElementById('divArea').style.display='none';
                     n=0;firsttime=0;
                }
                else
                {
                        if(areas!=null)
                        {
                        var x;
                        var index=0;
                        var str_sort_index_array=new Array();                       
                                for(i=0;i<areas.length;i++)
                                {
                                    x= areas[i].getAttribute("name");                                   
                                    if(value.toUpperCase()!='TYPE AREA' &&  areas[i].getAttribute("name").length>=value.length && (areas[i].getAttribute("name").substring(0,value.length).toUpperCase()==value.toUpperCase() || (x.toUpperCase().indexOf(value.toUpperCase())!=-1  && x.toUpperCase().indexOf(value.toUpperCase())>1)))
                                    {                                    
                                        str_sort_index_array[index]=x.toUpperCase().indexOf(value.toUpperCase())+",a"+i+","+areas[i].getAttribute("id")+","+areas[i].getAttribute("name");                                       
                                        note=1;
                                        index++;
                                    }
                                    else if(value==''|| value.toUpperCase()=='TYPE AREA')
                                    {
                                         str_sort_index_array[index]=x.toUpperCase().indexOf(value.toUpperCase())+",a"+i+","+areas[i].getAttribute("id")+","+areas[i].getAttribute("name");
                                         note=1;
                                         index++;
                                    }
                                }                             
                               if(value!='' && value.toUpperCase()!='TYPE AREA')
                               {                              
                                 str_sort_index_array.sort();
                               }
                                var final_areas= new Array();
                                var name,areaid;
                                for(var j=0;j<str_sort_index_array.length;j++)
                                {                                    
                                   final_areas=str_sort_index_array[j].split(",");
                                    for(var k=0;k<=3;k++)
                                    {                                        
                                        areaid="";
                                        name="";                                        
                                         areaid=final_areas[2];
                                         name=final_areas[3];
                                         break;
                                     }                                     
                                     strHtml +="<span name='allAreas' id='a"+j+"' onclick=\'addArea("+areaid+",\""+name+"\")\'>"+name+"</span>";
                                }                   
                        if(note==0)
                        strHtml="Sorry no matching area found";
                        document.getElementById('divAllArea').innerHTML=strHtml; 
                        if(e)keyUpDownArea(e);
                        }
                  }
            }
            else
            keyUpDownArea(e)
       }           
       // showSeletedCity(this.event);
       showSeletedCountry(this.event);
         if(document.getElementById('txtHdnCountryId').value!='0')
             {
                    for(i=0;i<Countries.length;i++)
                    {
                        if(Countries[i][0]==document.getElementById('txtHdnCountryId').value)
                        {
                            //document.getElementById('txtCountry').value="India";
                            AddAjaxCity(Countries[i][0],1);
                            existingCountryId=Countries[i][0];
                            break;
                        }
                    }
            }      
        if((navigator.appName).toUpperCase()=="OPERA")
        {
            document.getElementById('divcity').style.left='470px';
            document.getElementById('divArea').style.left='680px';
        }
     if(document.getElementById('txtHdnCountryId').value!='0')
         {
          AddAjaxCity(document.getElementById('txtHdnCountryId').value,1);
         }
      if(document.getElementById('txtHdnCityId').value!='0')
         {
          AddAjaxAreas(document.getElementById('txtHdnCityId').value,1);
         } 
        <!-- Copyright 2006,2007 Bontrager Connection, LLC
// http://bontragerconnection.com/ and http://willmaster.com/
// Version: July 28, 2007
function findPosX(obj)
  {
    var curleft = 0;
    if(obj.offsetParent)
        while(1) 
        {
          curleft += obj.offsetLeft;
          if(!obj.offsetParent)
            break;
          obj = obj.offsetParent;
        }
    else if(obj.x)
        curleft += obj.x;
    return curleft;
  }
  function findPosY(obj)
  {
    var curtop = 0;
    if(obj.offsetParent)
        while(1)
        {
          curtop += obj.offsetTop;
          if(!obj.offsetParent)
            break;
          obj = obj.offsetParent;
        }
    else if(obj.y)
        curtop += obj.y;
    return curtop;
  }
function HideContent(d) {
if(d.length < 1) { return; }
document.getElementById(d).style.display = "none";
}
function ShowContent(d) {
if(d.length < 1) { return; }
var dd = document.getElementById(d);
dd.style.left = findPosX(document.getElementById('Button1'))+0 + "px";
dd.style.top = findPosY(document.getElementById('Button1'))+26 + "px";
dd.style.display = "block";
}
function ReverseContentDisplay(d) {
if(d.length < 1) { return; }
var dd = document.getElementById(d);
dd.style.left = findPosX(document.getElementById('Button1'))+10 + "px";
dd.style.top = findPosY(document.getElementById('Button1'))+26 + "px";
if(dd.style.display == "none") { dd.style.display = "block"; }
else { dd.style.display = "none"; }
}
//-->
function stopHere()
{
   document.getElementById("uniquename3").style.display='none';
}
function addInputSubmitEvent(form, input) {
    if(input.id!="txt_srctxt")
    {
        input.onkeydown = function(e) {
            e = e || window.event;
            if (e.keyCode == 13) {
                //form.submit();
                return false;
            }
        };
    }
    else
    {  
        input.onkeydown = function(e) {
            e = e || window.event;
            if (e.keyCode == 13) 
            {
             var strLen=document.getElementById("txt_srctxt").value.trim()            
                if(strLen.length<2)
                {              
                 alert("Please enter atleast 2 characters.");
                return false;
                }
                else
                { GoToNamingSearch(e);}
                return false;
            }
        };
    }
}
window.onload = function() {
    var forms = document.getElementsByTagName('form');
    for (var i=0;i < forms.length;i++) {
        var inputs = forms[i].getElementsByTagName('input');
        for (var j=0;j < inputs.length;j++)
            addInputSubmitEvent(forms[i], inputs[j]);
    }
};
/* show tooltip div in search page to contact bussinessman*/
    function noAction(e) {
    }
 function divCountries()    
    {               
            showSeletedCountry(this.event);          
    }
function divCities() {
      //  document.getElementById('ViewCountry').style.display='none';
        document.getElementById('divArea').style.display='none';  
        document.getElementById('txtHdnCountryId').value='1';                
        if(document.getElementById('txtHdnCountryId').value!="0") {      
            if(cities ==null || cities.length==0)
             { 
                AddAjaxCity(document.getElementById('txtHdnCountryId').value,0);
                setBackText(document.getElementById('txtCity'));
                document.getElementById('txtActCity').value='Select City';
                document.getElementById('divcity').style.display='inline';
              //  document.getElementById('ViewCountry').style.display='none';
                document.getElementById('divcity').style.display='none';   
                document.getElementById('imgload').style.display='none';
            } 
            else
            {  
             document.getElementById('divcity').style.display='inline';
             document.getElementById('txtCity').focus();
             document.getElementById('txtCity').value = ' ';
             showSeletedCity(this.event);
             //document.getElementById('txtCity').value=' ';
            }
        }
        else
            alert("Please select any country");  
    }        
   // <!-- Copyright 2006,2007 Bontrager Connection, LLC
// http://bontragerconnection.com/ and http://willmaster.com/
// Version: July 28, 2007
function findPosX(obj)
  {
    var curleft = 0;
    if(obj.offsetParent)
        while(1) 
        {
          curleft += obj.offsetLeft;
          if(!obj.offsetParent)
            break;
          obj = obj.offsetParent;
        }
    else if(obj.x)
        curleft += obj.x;
    return curleft;
  }
  function findPosY(obj)
  {
    var curtop = 0;
    if(obj.offsetParent)
        while(1)
        {
          curtop += obj.offsetTop;
          if(!obj.offsetParent)
            break;0
          obj = obj.offsetParent;
        }
    else if(obj.y)
        curtop += obj.y;
    return curtop;
  }
function HideContent(d) {
if(d.length < 1) { return; }
document.getElementById(d).style.display = "none";
}
function ShowContent(d) {
if(d.length < 1) { return; }
var dd = document.getElementById(d);
dd.style.left = findPosX(document.getElementById('Button1'))+10 + "px";
dd.style.top = findPosY(document.getElementById('Button1'))+26 + "px";
dd.style.display = "block";
}
function ReverseContentDisplay(d) {
if(d.length < 1) { return; }
var dd = document.getElementById(d);
dd.style.left = findPosX(document.getElementById('Button1'))+10 + "px";
dd.style.top = findPosY(document.getElementById('Button1'))+26 + "px";
if(dd.style.display == "none") { dd.style.display = "block"; }
else { dd.style.display = "none"; }
}
//-->
function stopHere()
{
   document.getElementById("uniquename3").style.display='none';
}
///page code replaced in js by sanjeev as on 13/9/2012
// code for bussiness blue image up down
var interValId = window.setInterval(showAddBusiness, 400);
var moveUp = 0;
function showAddBusiness() {
    if (document.getElementById('divAddBusiness')) {
        document.getElementById('divAddBusiness').style.display = 'none';
        //        if ((moveUp % 2) == 0) {
        //            document.getElementById('divAddBusiness').style.marginTop = '4px';
        //        }
        //        else {
        //            document.getElementById('divAddBusiness').style.marginTop = '-4px';
        //        }
        //        moveUp++;
        //        if (moveUp == 20) {
        //            clearInterval(interValId);
        //            document.getElementById('divAddBusiness').style.display = 'none';
        //        }
    }
}
// code for bussiness blue image close
if (document.getElementById('divSlider')) {
    document.getElementById('divSlider').style.display = 'none';
}
if (document.getElementById('divloading')) {
    document.getElementById('divloading').style.display = 'block';
}
//setTimeout("setToShow()", 2000);
function setToShow() {
    document.getElementById('div_adv_blink').style.display = 'block';
    document.getElementById('div_adv_blink').style.visibility = 'visible';
    document.getElementById('div_adv_blink_blank').style.display = 'none';
    document.getElementById('div_adv_blink_blank').style.visibility = 'hidden';
    setTimeout("setToHide()", 2400);
}
function setToHide() {
    document.getElementById('div_adv_blink').style.display = 'none';
    document.getElementById('div_adv_blink').style.visibility = 'hidden';
    document.getElementById('div_adv_blink_blank').style.display = 'block';
    document.getElementById('div_adv_blink_blank').style.visibility = 'visible';
    setTimeout("setToShow()", 2000);
}
function enterToClickSubmit1(e) {
    var code;
    if (!e) {
        var e = window.event;
      }
    if (e.keyCode) {
         code = e.keyCode; 
     }
     else if (e.which) 
    { code = e.which; }
    if (code == 13) 
    {  ReviewPost(); return false; }
}
function ReplaceAll(sourecestring, stringtofind, stringtoreplace) {
    var temp = sourecestring;
    var index = temp.toString().indexOf(stringtofind);
    while (index != -1) {
        temp = temp.replace(stringtofind, stringtoreplace);
        index = temp.indexOf(stringtofind);
    }
    return temp;
}
if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) { //test for MSIE x.x;
    var ieversion = new Number(RegExp.$1) // capture x.x portion and store as a number
    if (ieversion >= 8) { }
    else if (ieversion >= 7) { }
    else if (ieversion >= 5) {
        if (document.getElementById('divAllCities')) {
            document.getElementById('divAllCities').style.height = 150 + 'px';
        }
        if (document.getElementById('divAllArea')) {
            document.getElementById('divAllArea').style.height = 150 + 'px';
        }
    }
}
function HideCity(from) {
    try {
        if (from == 'nat') {
            document.getElementById('CityDiv').style.display = 'none';
            document.getElementById('txt_srctxt').value = '';
            document.getElementById("txt_srctxt").focus();
            document.getElementById("div_Navigation").innerHTML = '';
            document.getElementById("divContent").style.textAlign = 'Center'
            document.getElementById("divContent").style.display = 'none';
            document.getElementById("divFooter").style.position = 'fixed';
            document.getElementById("divFooter").style.marginLeft = 420 + 'px'
            document.getElementById("divFooter").style.bottom = 40 + 'px';
        }
        else if (from == 'city') {
            document.getElementById('CityDiv').style.display = 'block';
            document.getElementById('txt_srctxt').value = '';
            document.getElementById("txt_srctxt").focus();
            document.getElementById("div_Navigation").innerHTML = '';
            document.getElementById("divContent").style.textAlign = 'Center'
            document.getElementById("divContent").style.display = 'none';
            document.getElementById("divFooter").style.position = 'fixed';
            document.getElementById("divFooter").style.marginLeft = 420 + 'px'
            document.getElementById("divFooter").style.bottom = 40 + 'px';
        }
    }
    catch (err) { }
}
if ((/MSIE (\d+\.\d+);/.test(navigator.userAgent))) {
    if (document.getElementById('spnEmcopy')) {
        document.getElementById('spnEmcopy').style.display = 'inline';
    }
}
function hideLoading(sts) {
    if (sts == 1) {
        if (document.getElementById('divloading')) {
            document.getElementById('divloading').style.display = 'none';
        }
    }
}
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=");
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length;
            return unescape(document.cookie.substring(c_start, c_end));
        }
    }
    return "";
}
function setCookie(c_name, value, expiredays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + expiredays);
    document.cookie = c_name + "=" + escape(value) + ((expiredays == null) ? "" : ";expires=" + exdate.toUTCString()) + ";path=" + "/";
}
function Redirect(Chk)
{
    if(Chk==2)
    {
        window.location.href = "https://www.tingtongindia.com/";
    }
    else  if(Chk== 1)
    {
       window.location.href = "http://usa.tingtongindia.com/";
    }
}
// BlinkWant();                         
//  function BlinkWant()
//  {     
//        document.getElementById("Advertse").innerHTML = '<div><a href="2ndGetPhoneNo.aspx"  rel="nofollow"  id="div_advertise"> See your business always on top. Beat your competition, <span>How ?</span></a> </div>';
//       // setTimeout("BlinkWantNEXT()", 500);
//  }
//  
//  function BlinkWantNEXT() {    
//   document.getElementById("Advertse").innerHTML = '<div style=" width:47%; padding:3px;color:#024370;font-size:15px;"> See your business always on top.&nbsp;&nbsp;Beat your competition,&nbsp;&nbsp;<a  href="2ndGetPhoneNo.aspx"  rel="nofollow" style="font-size: 15px; display:inline;color: #365f91; outline: none;" id="div_advertise"><span style="color:Red;"><b>How ?</b></a></span> </div>';
//   setTimeout("BlinkWant()", 700);
//  }
function clickDiv(cityName, CityID,keyword)
{
    if(cityName=="0" || cityName=="Select-City")
    {
      var LocalCityName=document.getElementById("HdnCityName").value;   
      Rdt(LocalCityName);
      var NewCityID=document.getElementById('HdnCityIDNew').value;    
      if(NewCityID=="0")
      {
            NewCityID="1";
            LocalCityName="Nashik";
            window.location.href=siteUrlNew+ LocalCityName + '/'+keyword+'-C'+NewCityID;
      }
      else{
       window.location.href=siteUrlNew+ LocalCityName + '/'+keyword+'-C'+NewCityID;
      }  
    }
    else
    {
    window.location.href=siteUrlNew+ cityName + '/'+keyword+'-C'+CityID;
    }
}
  BindAllStaticData();
function BindAllStaticData()
{
                var cityIdCategory= document.getElementById('txtHdnCityId').value;
                var CityName = document.getElementById('txtActCity').value.trim();     
                var strCategories="";
              document.getElementById("divITCompanies").innerHTML = "<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Top-IT-Companies')\" class=\"gl-btn gl-btn-white uppercase\">View All <i class=\"fa fa-long-arrow-right\"></i></div>";
                document.getElementById("divHospitals").innerHTML = "<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Hospitals')\" class=\"gl-btn gl-btn-white uppercase\">View All <i class=\"fa fa-long-arrow-right\"></i></div>";
               document.getElementById("divEducationInstitutes").innerHTML = "<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Educational-Institutes')\"  class=\"gl-btn gl-btn-white uppercase\">View All <i class=\"fa fa-long-arrow-right\"></i></div>";
                strCategories+="<div class=\"gl-cats-box _1\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/tour-travels.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Tours and Travels</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _1\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Tours and Travels</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";                
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Travel-Agents')\" class=\"gl-cats-submenu-link\">Travel Agents </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Family-Tour-Packages')\" class=\"gl-cats-submenu-link\">Family Tour Packages </div>";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','International-Tour-Packages')\" class=\"gl-cats-submenu-link\">International Tour Packages </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Domestic-Tour-Packages')\" class=\"gl-cats-submenu-link\">Domestic Tour Packages </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Honeymoon-Tour-Packages')\" class=\"gl-cats-submenu-link\">Honeymoon Tour Packages</div>";               
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _2\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/astrologers.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Astrologers</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _2\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Astrologers</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Astrologers')\" class=\"gl-cats-submenu-link\">Astrologers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Pandits')\" class=\"gl-cats-submenu-link\">Pandits </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Palm-Reading')\" class=\"gl-cats-submenu-link\">Palm Reading</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Numerologists')\" class=\"gl-cats-submenu-link\">Numerologists </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Face-Reading-Astrologers')\" class=\"gl-cats-submenu-link\">Face Reading Astrologers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Vastu-Consultants')\" class=\"gl-cats-submenu-link\">Vastu Consultants </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Gemstone-Dealers')\" class=\"gl-cats-submenu-link\">Gemstone Dealers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Tarot-Card-Readers')\" class=\"gl-cats-submenu-link\">Tarot Card Readers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Vedic-Astrologers')\" class=\"gl-cats-submenu-link\">Vedic Astrologers </div>";                
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _3\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/training-institute.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Training Institutes</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _3\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Training Institutes</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
               strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Bank-Coaching')\" class=\"gl-cats-submenu-link\">Bank Coaching </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','SSC-Coaching')\" class=\"gl-cats-submenu-link\">SSC Coaching </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','IAS-Coaching')\" class=\"gl-cats-submenu-link\">IAS Coaching </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Six-Months-Industrial-Training')\" class=\"gl-cats-submenu-link\">Six Months Industrial Training </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Computer-Courses')\" class=\"gl-cats-submenu-link\">Computer Courses</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','IELTS-Coaching')\" class=\"gl-cats-submenu-link\">IELTS Coaching </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','PTE-Coaching')\" class=\"gl-cats-submenu-link\">PTE Coaching</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Cyber-Security-Training-Courses')\" class=\"gl-cats-submenu-link\">Cyber Security Training Courses </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','OET-Coaching')\" class=\"gl-cats-submenu-link\">OET Coaching</div>"; 
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','English-Speaking-Classes')\" class=\"gl-cats-submenu-link\">English Speaking Classes </div>";    
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _4\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/packers.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Packers and Movers</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _4\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Packers and Movers</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Packers-and-Movers')\" class=\"gl-cats-submenu-link\">Packers and Movers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Local-Shifting-Services')\" class=\"gl-cats-submenu-link\">Local Shifting Services </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','International-Shifting-Services')\" class=\"gl-cats-submenu-link\">International Shifting Services </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Home-Shifting-Services')\" class=\"gl-cats-submenu-link\">Home Shifting Services </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Car-Transport-Services')\" class=\"gl-cats-submenu-link\">Car Transport Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Office-Relocation-Services')\" class=\"gl-cats-submenu-link\">Office Relocation Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Home-Relocation-Services')\" class=\"gl-cats-submenu-link\">Home Relocation Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Commercial-Moving-Services')\" class=\"gl-cats-submenu-link\">Commercial Moving Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Packing-And-Moving-Services')\" class=\"gl-cats-submenu-link\">Packing And Moving Services</div>";                                
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _5\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/interior.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Interior Services</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _5\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Interior Services</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Interior-Designers')\" class=\"gl-cats-submenu-link\">Interior Designers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Interior-Decorators')\" class=\"gl-cats-submenu-link\">Interior Decorators </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Interior-Architects')\" class=\"gl-cats-submenu-link\">Interior Architects </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Commercial-Architects')\" class=\"gl-cats-submenu-link\">Commercial Architects </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Residential-Architects')\" class=\"gl-cats-submenu-link\">Residential Architects</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Office-Interior-Designers')\" class=\"gl-cats-submenu-link\">Office Interior Designers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Home-Interior-Designers')\" class=\"gl-cats-submenu-link\">Home Interior Designers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Kids-Room-Interior-Designers')\" class=\"gl-cats-submenu-link\">Kids Room Interior Designers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Architect-and-Interior-Designer')\" class=\"gl-cats-submenu-link\">Architect and Interior Designer</div>";                                
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Design-Square-Architects')\" class=\"gl-cats-submenu-link\">Design Square Architects</div>";                                              
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _6\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/event.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Event Management</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _6\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Event Management</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Wedding-Planners')\" class=\"gl-cats-submenu-link\">Wedding Planners </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Corporate-Event-Management-Services')\" class=\"gl-cats-submenu-link\">Corporate Event Management Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Event-Management-Services')\" class=\"gl-cats-submenu-link\">Event Management Services </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Promotional-Events')\" class=\"gl-cats-submenu-link\">Promotional Events </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Birthday-Event-Planners')\" class=\"gl-cats-submenu-link\">Birthday Event Planners</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Party-Organisers')\" class=\"gl-cats-submenu-link\">Party Organisers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Event-Organisers')\" class=\"gl-cats-submenu-link\">Event Organisers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Corporate-Event-Organisers')\" class=\"gl-cats-submenu-link\">Corporate Event Organisers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Product-Launch-Organisers')\" class=\"gl-cats-submenu-link\">Product Launch Organisers</div>";                                
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _7\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/properties.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Real Estate</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _7\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Real Estate</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                  strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Real-Estate-Agents')\" class=\"gl-cats-submenu-link\">Real Estate Agents </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Property-Consultants')\" class=\"gl-cats-submenu-link\">Property Consultants</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Raivat-Property-Advisory')\" class=\"gl-cats-submenu-link\">Raivat Property Advisory</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Commercial-Property-Agents')\" class=\"gl-cats-submenu-link\">Commercial Property Agents </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Property-Dealers')\" class=\"gl-cats-submenu-link\">Property Dealers</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _8\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/services-center.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Service And Repair Centers</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _8\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Service And Repair Centers</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Samsung-AC-Service-Center')\" class=\"gl-cats-submenu-link\">Samsung AC Service Center </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','IFB-Washing-Machine-Service-Center')\" class=\"gl-cats-submenu-link\">IFB Washing Machine Service Center</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Refrigerator-Service-Centers')\" class=\"gl-cats-submenu-link\">Refrigerator Service Centers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Laptop-Repair-Services')\" class=\"gl-cats-submenu-link\">Laptop Repair Services </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Car-Service-Centers')\" class=\"gl-cats-submenu-link\">Car Service Centers</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Apple-Service-Center')\" class=\"gl-cats-submenu-link\">Apple Service Center </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Samsung-Service-Center')\" class=\"gl-cats-submenu-link\">Samsung Service Center</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Authorised-Oppo-Service-Center')\" class=\"gl-cats-submenu-link\">Authorised Oppo Service Center</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Vivo-Service-Center')\" class=\"gl-cats-submenu-link\">Vivo Service Center </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Xiaomi-Authorised-Service-Center')\" class=\"gl-cats-submenu-link\">Xiaomi Authorised Service Center</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _9\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/it.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>IT Companies</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _9\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">IT Companies</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Web-Development-Companies')\" class=\"gl-cats-submenu-link\">Web Development Companies </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Internet-Marketing-Services')\" class=\"gl-cats-submenu-link\">Internet Marketing Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Website-Designing-Services')\" class=\"gl-cats-submenu-link\">Website Designing Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Software-Development-Companies')\" class=\"gl-cats-submenu-link\">Software Development Companies </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Mobile-Application-Development')\" class=\"gl-cats-submenu-link\">Mobile Application Development</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Software-Testing-Companies')\" class=\"gl-cats-submenu-link\">Software Testing Companies</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Cloud-Computing-Services')\" class=\"gl-cats-submenu-link\">Cloud Computing Services</div>";
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _10\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/hotels.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Wedding Services</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _10\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Wedding Services</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Wedding-Halls')\" class=\"gl-cats-submenu-link\">Wedding Halls </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Wedding-Planners')\" class=\"gl-cats-submenu-link\">Wedding Planners</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Dance-Groups')\" class=\"gl-cats-submenu-link\">Dance Groups</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Helicopter-Booking-Service-For-Wedding')\" class=\"gl-cats-submenu-link\">Helicopter Booking Service For Wedding </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Wedding-Cards')\" class=\"gl-cats-submenu-link\">Wedding Cards</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Flower-Decorators')\" class=\"gl-cats-submenu-link\">Flower Decorators</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Mehendi-Artists')\" class=\"gl-cats-submenu-link\">Mehendi Artists</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Ghodi-Orchestras')\" class=\"gl-cats-submenu-link\">Ghodi Orchestras</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Malwai-Giddha-Groups')\" class=\"gl-cats-submenu-link\">Malwai Giddha Groups</div>";
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _11\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/strong.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Health and Fitness</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _11\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Health and Fitness</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Yoga-Centers')\" class=\"gl-cats-submenu-link\">Yoga Centers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Gyms')\" class=\"gl-cats-submenu-link\">Gyms</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Meditation-Centers')\" class=\"gl-cats-submenu-link\">Meditation Centers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Weight-Loss-Centers')\" class=\"gl-cats-submenu-link\">Weight Loss Centers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Thai-Massage')\" class=\"gl-cats-submenu-link\">Thai Massage</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Swedish-Massage')\" class=\"gl-cats-submenu-link\">Swedish Massage</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Sparsh-Child-Guidance-and-Rehabilitation-Centre-For-Children')\" class=\"gl-cats-submenu-link\">Sparsh Child Guidance and Rehabilitation Centre For Children</div>";
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _12\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/cafe.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Hotels And Restaurant</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _12\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Restaurant</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";  
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Hotels')\" class=\"gl-cats-submenu-link\">Hotels </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Luxury-Hotels')\" class=\"gl-cats-submenu-link\">Luxury Hotels</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Budget-Hotels')\" class=\"gl-cats-submenu-link\">Budget Hotels</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Bars')\" class=\"gl-cats-submenu-link\">Bars</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Chinese-Restaurants')\" class=\"gl-cats-submenu-link\">Chinese Restaurants</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Clubs')\" class=\"gl-cats-submenu-link\">Clubs</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Ice-Cream-Parlours')\" class=\"gl-cats-submenu-link\">Ice Cream Parlours</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Wine-and-Liquor-Shops')\" class=\"gl-cats-submenu-link\">Wine and Liquor Shops</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Coffee-Shops')\" class=\"gl-cats-submenu-link\">Coffee Shops</div>";
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _13\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/hospitals.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Hospitals</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _13\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Hospitals And Clinics</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Charitable-Hospitals')\" class=\"gl-cats-submenu-link\">Charitable Hospitals </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Government-Hospitals')\" class=\"gl-cats-submenu-link\">Government Hospitals</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Eye-Hospitals')\" class=\"gl-cats-submenu-link\">Eye Hospitals</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Dental-Hospitals')\" class=\"gl-cats-submenu-link\">Dental Hospitals</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Skin-Hospitals')\" class=\"gl-cats-submenu-link\">Skin Hospitals</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Ayurvedic-Hospitals')\" class=\"gl-cats-submenu-link\">Ayurvedic Hospitals</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Eye-Hospitals')\" class=\"gl-cats-submenu-link\">Eye Hospitals</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Homeopathic-Clinics')\" class=\"gl-cats-submenu-link\">Homeopathic Clinics</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Veterinary-Clinics')\" class=\"gl-cats-submenu-link\">Veterinary Clinics</div>";
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _14\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/manufacturers.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Manufacturers and Dealers</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _14\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Manufacturers and Dealers</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Silicone-Rubber-Manufacturers')\" class=\"gl-cats-submenu-link\">Silicone Rubber Manufacturers </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Plastic-Manufacturers')\" class=\"gl-cats-submenu-link\">Plastic Manufacturers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Textile-Manufacturers')\" class=\"gl-cats-submenu-link\">Textile Manufacturers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Fertilizer-Dealers')\" class=\"gl-cats-submenu-link\">Fertilizer Dealers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Herbal-Beauty-Product-Dealers')\" class=\"gl-cats-submenu-link\">Herbal Beauty Product Dealers</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Boiler-Manufacturers')\" class=\"gl-cats-submenu-link\">Boiler Manufacturers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Wool-Handicraft-Manufacturers')\" class=\"gl-cats-submenu-link\">Wool Handicraft Manufacturers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Bearing-Dealers')\" class=\"gl-cats-submenu-link\">Bearing Dealers</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Bike-Dealers')\" class=\"gl-cats-submenu-link\">Bike Dealers</div>";
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _15\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/doctors.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Doctors</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _15\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Doctors</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Orthopedic-Doctors')\" class=\"gl-cats-submenu-link\">Orthopedic Doctors </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Homeopathic-Doctors')\" class=\"gl-cats-submenu-link\">Homeopathic Doctors</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Doctors-Cardiologist')\" class=\"gl-cats-submenu-link\">Doctors Cardiologist</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Doctors-Psychologist')\" class=\"gl-cats-submenu-link\">Doctors Psychologist</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Doctors-Gynaecologist')\" class=\"gl-cats-submenu-link\">Doctors Gynaecologist</div>";                               
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Doctors-Neurologist')\" class=\"gl-cats-submenu-link\">Doctors Neurologist</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Doctors-Ear-Specialist')\" class=\"gl-cats-submenu-link\">Doctors Ear Specialist </div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Sexologist-Doctors')\" class=\"gl-cats-submenu-link\">Sexologist Doctors</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";                
                strCategories+="<div class=\"gl-cats-box _16\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/courier-services.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Courier Services</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _16\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Courier Services</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','International-Courier-Services')\" class=\"gl-cats-submenu-link\">International Courier Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Domestic-Courier-Services')\" class=\"gl-cats-submenu-link\">Domestic Courier Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Express-Delivery-Services')\" class=\"gl-cats-submenu-link\">Express Delivery Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Document-Courier-Services')\" class=\"gl-cats-submenu-link\">Document Courier Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Bulk-Courier-Services')\" class=\"gl-cats-submenu-link\">Bulk Courier Services</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _17\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/immigration.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Immigration</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _17\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Immigration</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Student-Visa-Consultants')\" class=\"gl-cats-submenu-link\">Student Visa Consultants</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Business-Visa-Consultants')\" class=\"gl-cats-submenu-link\">Business Visa Consultants</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Tourist-Visa-Consultants')\" class=\"gl-cats-submenu-link\">Tourist Visa Consultants</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Dependent-Visa-Consultants')\" class=\"gl-cats-submenu-link\">Dependent Visa Consultants</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Passport-Consultants')\" class=\"gl-cats-submenu-link\">Passport Consultants</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _18\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/education.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Placement Consultants</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _18\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Placement Consultants</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Job-Placement-Agencies')\" class=\"gl-cats-submenu-link\">Job Placement Agencies</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Contract-Staffing-Services')\" class=\"gl-cats-submenu-link\">Contract Staffing Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','IT-Job-Consultants')\" class=\"gl-cats-submenu-link\">IT Job Consultants</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','International-Placement-Consultants')\" class=\"gl-cats-submenu-link\">International Placement Consultants</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','BPO-Consultants')\" class=\"gl-cats-submenu-link\">BPO Consultants</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _19\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/pharma.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Pharmaceuticals Manufacturer</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _19\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Pharmaceuticals Manufacturer</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                 strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Pharmaceutical-Companies')\" class=\"gl-cats-submenu-link\">Pharmaceutical Companies</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Pharmaceutical-Machines')\" class=\"gl-cats-submenu-link\">Pharmaceutical Machines</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Pharmaceutical-Medicine-Manufacturers')\" class=\"gl-cats-submenu-link\">Pharmaceutical Medicine Manufacturers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Pharmaceutical-Distributors')\" class=\"gl-cats-submenu-link\">Pharmaceutical Distributors</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Veterinary-Pharmaceutical-Dealers')\" class=\"gl-cats-submenu-link\">Veterinary Pharmaceutical Dealers</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-box _20\">";
    strCategories +="<span class=\"gl-cats-icon\"><img src='/Frontwebsitedesign/images/services-center.svg' alt='category' width='75'></span>";
                strCategories+="<h4 class='gl-cats-title'>Daily Needs</h4>";
                strCategories+="</div>";
                strCategories+="<div class=\"gl-cats-submenu _20\">";
                strCategories+="<h4 class=\"gl-cats-submenu-title\">Daily Needs</h4>";
                strCategories+="<nav class=\"gl-cats-submenu-nav\">";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Drinking-Water-Suppliers')\" class=\"gl-cats-submenu-link\">Drinking Water Suppliers</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Fruits-and-Vegetables')\" class=\"gl-cats-submenu-link\">Fruits and Vegetables</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Tiffin-Services')\" class=\"gl-cats-submenu-link\">Tiffin Services</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Fuel-Stations')\" class=\"gl-cats-submenu-link\">Fuel Stations</div>";
                strCategories+="<div onClick=\"javascript:clickDiv('"+CityName.replace(/ /g,'-')+"','"+cityIdCategory+"','Cyber-Cafes')\" class=\"gl-cats-submenu-link\">Cyber Cafes</div>";                               
                strCategories+="</nav>";
                strCategories+="</div>";
               document.getElementById("DivCategories").innerHTML=strCategories;
              //  DivCategories.InnerHtml = strCategories.ToString();
}
function Rdt(CityName) {
    var phrse = CityName;    
       xmlhttp=GetXmlHttpObject();
    xmlhttp.onreadystatechange = Rdt_Callback;
    var param = 'phrse=' + CityName + "&Action=oncitybind";
    var url = siteUrl + "Handler/ajax.ashx?" + param; 
    xmlhttp.open('GET', url, true);
    xmlhttp.send(null);
    return false;
}
function Rdt_Callback() {
    if (xmlhttp.readyState == 4 || xmlhttp.readyState == "complete") {
        var txt = xmlhttp.responseText;
       // alert(txt);
        if (txt != '') {
            document.getElementById('HdnCityIDNew').value = txt;
        }
    }
}
