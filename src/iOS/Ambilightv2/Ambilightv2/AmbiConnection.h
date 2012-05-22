//
//  AmbiConnection.h
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 28/04/12.
//  Copyright (c) 2012. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface AmbiConnection : NSObject <NSStreamDelegate> {
    NSInputStream *inputStream;
    NSOutputStream *outputStream;
    NSString *ipAdres;
}

// Properties
@property (nonatomic, strong) NSString *ipAdres;


// Singleton constructor
+ (AmbiConnection *) sharedConnection;

// Methoden
- (void) initNetworkCommunication;
- (BOOL) openConnection;
- (void) closeConnection;
- (BOOL) isConnected;
- (void) sendMessage:(NSString *) message;

@end