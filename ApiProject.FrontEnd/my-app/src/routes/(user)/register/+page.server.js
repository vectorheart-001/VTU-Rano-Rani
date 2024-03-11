import {error, fail, json, redirect} from '@sveltejs/kit';

/** @type {import('./$types').Actions} */


export const actions ={
    default:async ({request,cookies}) =>{
       
        const data = await request.formData()
        const firstName =data.get('firstName')
        const secondName =data.get('secondName')
        const lastName = data.get('lastName')
        const email = data.get('email')
        const phone = data.get('phone')
        const personalId =data.get('personalId')
        var payload =
        {
            firstName:String(firstName),
            secondName:String(secondName),
            lastName:String(lastName),
            personalId :String(personalId),
            email :String(email),
            phone :String(phone),
            
        }
        const response = await fetch(`http://localhost:7162/User/Register`,
        { 
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        },
        
        
        
        
    )
    console.log(response.status)
    if (response.status == 409)
    {

        return fail(500,{
            error:"Този Е-mail вече е полза"}
        )
    }
    else if (response.status == 404){
        return fail(500,{
            error:"Вече има потребител със същoтo ЕГН"}
        )
    }
    else if(response.status == 400)
    {
        return fail(500,{
            error:"Form error"}
        )
    }
    else{
       
        throw redirect(302, "/login");
    }
    }

}