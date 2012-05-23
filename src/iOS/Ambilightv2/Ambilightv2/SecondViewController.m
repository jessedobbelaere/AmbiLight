//
//  SecondViewController.m
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 20/05/12.
//  Copyright (c) 2012. All rights reserved.
//

#import "SecondViewController.h"
#import "AmbiConnection.h"
#include <arpa/inet.h>


@class AmbiConnection;
@interface SecondViewController ()

@end

@implementation SecondViewController
@synthesize ipAdresInput;
@synthesize errorLabel;
@synthesize connectButton;

// View has loaded
- (void)viewDidLoad {
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    NSLog(@"Settings geladen");  
    
    
    //Load user preferences
    NSString *ipAdres = [[NSUserDefaults standardUserDefaults] stringForKey: @"ipAdres"];
    NSLog(ipAdres);
    
    if([ipAdres length] != 0) {
        ipAdresInput.text = ipAdres;
    }

}


// View did unload
- (void)viewDidUnload
{
    [self setIpAdresInput:nil];
    [self setConnectButton:nil];
    [self setErrorLabel:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}


- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}


// The connect button is pressed 
-(IBAction)ConnectPressed:(id)sender {    
    [ipAdresInput resignFirstResponder]; // Hide the keyboard
    
    AmbiConnection *ambiConnection = [AmbiConnection sharedConnection];
    
    if([self isIp:ipAdresInput.text]) {
        ambiConnection.ipAdres = ipAdresInput.text;
        NSLog(@"I will try to make a connection with ip: %@", ambiConnection.ipAdres);
        
        [ambiConnection initNetworkCommunication];
        if([ambiConnection openConnection]) {
            NSLog(@"Connected!");
        } else {
            NSLog(@"Foutje!");
        }
        
        // Save IP to user preferences
        NSUserDefaults *userDefaults = [NSUserDefaults standardUserDefaults];
        [userDefaults setObject:ambiConnection.ipAdres forKey:@"ipAdres"];
    }
    
}

// Hide the keyboard when return button is pressed
-(IBAction)textFieldReturn:(id)sender {
    [sender resignFirstResponder];
}

// Background was touched (hide the keyboard)
-(IBAction)backgroundTouched:(id)sender {
    [ipAdresInput resignFirstResponder];
}


// Is parameter an ip address?
- (BOOL)isIp:(NSString*)string{
    struct in_addr pin;
    int success = inet_aton([string UTF8String],&pin);
    if (success == 1) return TRUE;
    return FALSE;
}


@end
