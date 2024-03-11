import { error, redirect, type Handle, fail } from '@sveltejs/kit';
import { parse } from "svelte/compiler";
import jwt from 'jsonwebtoken'
import { sequence } from '@sveltejs/kit/hooks';

export const firstHandle = async ({ event, resolve }) => {
  const token = await event.cookies.get('token');

  const refreshToken = await event.cookies.get('refreshToken')
  if(token)
    {
      try{
        
      const jwtVerify = jwt.verify(token,import.meta.env.VITE_JWT_SECRET)
      
      const sessionUser = {
        id:jwtVerify.id,
        email:jwtVerify['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
        personalId:jwtVerify.personalId,
        request_status:jwtVerify.request_status,
        phone:jwtVerify.phone,
        name:jwtVerify.name,
        major:jwtVerify.major_id
      }
      event.locals.user = sessionUser;
      
      }
      
      catch(err){
        console.log(err)
      } 
  }
  
  
   
  else{
      event.locals.user = undefined;
  }
  const response = await resolve(event);
  return response
  
  };
  export const secondHandle = async ({ event, resolve }) => {
    const refreshToken = await event.cookies.get('refreshToken')
    if(!refreshToken) event.locals.user = undefined
    
    if(refreshToken)
      {
        try{
          
        const jwtVerify = jwt.verify(refreshToken,import.meta.env.VITE_JWT_SECRET_REFRESH)
        const test_parameter = `http://localhost:7162/User/refresh?` + new URLSearchParams({
          token:refreshToken
        })
        
        const response = await fetch(`http://localhost:7162/User/refresh?` + new URLSearchParams({
              token:refreshToken
          }),
          {  
            method: "Post",
            headers: { 
				    'Content-Type': 'application/json',
          },
          
        },
        )
        
        
        if (response.status == 400 || response.status == 404)
        {
          
          console.log("Something went wrong...")
          
        }
        else{
            const json = await response.json()
            event.cookies.set('token', json.accessToken, {
            path: '/',
            httpOnly: true,
            sameSite: 'strict',
            maxAge: 60 * 60 * 24 * 1000
        });
            event.cookies.set('refreshToken', json.refreshToken, {
            path: '/',
            httpOnly: true,
            sameSite: 'strict',
            maxAge: 60 * 60 * 24 * 2000
        });
          
          
        }

      }
        catch(err){
          console.log(err)
        } 
    }
    
     
    else{
        event.locals.user = undefined;
    }
    const response = await resolve(event);
    return response
    
    };
  export const handle = sequence(firstHandle,secondHandle)
  


    
     
    
  
  